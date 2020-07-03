using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;

namespace ParaglidingProject.Web.Controllers
{
    public class FlightsController : Controller
    {
        public enum FlightSort
        {
            NoSort = 0,
            DateAscending = 1,
            DateDescending = 2,
            PilotLastNameAscending = 3,
            PilotFirstNameAscending = 4,
            DateAscendingThenPilotFirstNameAscending = 5
        }


        const string apiAddressFlight = "http://localhost:50106/api/v1/flights";
        private readonly ParaglidingClubContext _context;
        public FlightsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index([FromForm]string SortList = "0")
        {
            
            List<SelectListItem> items = Enum.GetValues(typeof(FlightSort))
                                                .Cast<FlightSort>()
                                                .Select(v => new SelectListItem
                                                {
                                                    Text = v.ToString(),
                                                    Value = ((int)v).ToString()

                                                }).ToList();
            //ViewData["items"] = items;
            
            //foreach (var item in items)
            //{
            //    if (item.Selected)
            //    {
            //        userInput = item.Value;
            //    }
            //}



            ViewData["items"] = new SelectList(items, "Value", "Text");


            List<FlightDto> flightsDto = await LoadSortedList(SortList);

            return View(flightsDto);
        }

        private static async Task<List<FlightDto>> LoadSortedList(string userInput)
        {
            List<FlightDto> pFlightsDto;
            using (var httpClient = new HttpClient())
            {
                string fullApiAddress = $"{apiAddressFlight }?SortBy={userInput}";

                using (var response = await httpClient.GetAsync(fullApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pFlightsDto = JsonConvert.DeserializeObject<List<FlightDto>>(apiResponse);
                }
            }

            return pFlightsDto;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlightDto flightDto;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiAddressFlight + $"/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flightDto = JsonConvert.DeserializeObject<FlightDto>(apiResponse);
                }
            }

            return View(flightDto);
        }
    }
}
