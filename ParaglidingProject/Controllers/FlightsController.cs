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
        public enum FlightFilter
        {
            NoFilter = 0,
            TakeOffSite = 1,
            LandingSite = 2,
            ParagliderId = 3
        }


        const string apiAddressFlight = "http://localhost:50106/api/v1/flights";

        // GET: Flights
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> sortItems = LoadSortOptions();
            List<SelectListItem> filterItems = LoadFilterOptions();

            ViewData["sortItems"] = new SelectList(sortItems, "Value", "Text");
            ViewData["filterItems"] = new SelectList(filterItems, "Value", "Text");

            List<FlightDto> flightsDto;
            using (var httpClient = new HttpClient())
            {
                string fullApiAddress = $"{apiAddressFlight }";

                using (var response = await httpClient.GetAsync(fullApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flightsDto = JsonConvert.DeserializeObject<List<FlightDto>>(apiResponse);
                }
            }

            return View(flightsDto);
        }

        

        [HttpPost]
        public async Task<IActionResult> Index(string sortList, string filterList, string filterListId)
        {
            List<SelectListItem> sortItems = LoadSortOptions();
            List<SelectListItem> filterItems = LoadFilterOptions();

            ViewData["sortItems"] = new SelectList(sortItems, "Value", "Text");
            ViewData["filterItems"] = new SelectList(filterItems, "Value", "Text");

            List<FlightDto> flightsDto = await LoadList(sortList, filterList, filterListId);

            return View(flightsDto);
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
                using (var response = await httpClient.GetAsync($"{apiAddressFlight}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flightDto = JsonConvert.DeserializeObject<FlightDto>(apiResponse);
                }
            }

            return View(flightDto);
        }
        private static async Task<List<FlightDto>> LoadList(string userSort, string userFilter, string filterListId)
        {
            string test = "";
            switch (userFilter)
            {
                case "0":
                   break;
                case "1":
                    test = "TakeOffSiteId";
                    break;
                case "2":
                    test = "LandingSiteId";
                    break;
                case "3":
                    test = "ParagliderId";
                    break;
                default:
                    break;
            }

            List<FlightDto> pFlightsDto;
            using (var httpClient = new HttpClient())
            {
                string fullApiAddress = $"{apiAddressFlight }?SortBy={userSort}&FilterBy={userFilter}&{test}={filterListId}";

                using (var response = await httpClient.GetAsync(fullApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pFlightsDto = JsonConvert.DeserializeObject<List<FlightDto>>(apiResponse);
                }
            }
            return pFlightsDto;
        }
        private static List<SelectListItem> LoadFilterOptions()
        {
            List<SelectListItem> list = Enum.GetValues(typeof(FlightFilter))
                                                            .Cast<FlightFilter>()
                                                            .Select(v => new SelectListItem
                                                            {
                                                                Text = v.ToString(),
                                                                Value = ((int)v).ToString()

                                                            }).ToList();
            return list;
        }
        private static List<SelectListItem> LoadSortOptions()
        {
            List<SelectListItem> list = Enum.GetValues(typeof(FlightSort))
                                                            .Cast<FlightSort>()
                                                            .Select(v => new SelectListItem
                                                            {
                                                                Text = v.ToString(),
                                                                Value = ((int)v).ToString()

                                                            }).ToList();
            return list;
        }
    }
}
