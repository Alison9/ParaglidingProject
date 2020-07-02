using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;

namespace ParaglidingProject.Web.Controllers
{
    public class FlightsController : Controller
    {
        const string apiAddressFlight = "http://localhost:50106/api/v1/flights";
        private readonly ParaglidingClubContext _context;
        public FlightsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            List<FlightDto> flightsDto;
            using (var httpClient = new HttpClient())
            {
                StringBuilder Sb = new StringBuilder(apiAddressFlight);
                using (var response = await httpClient.GetAsync(apiAddressFlight))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flightsDto = JsonConvert.DeserializeObject<List<FlightDto>>(apiResponse);
                }
            }

            
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
