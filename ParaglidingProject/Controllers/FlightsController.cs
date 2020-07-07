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
using Newtonsoft.Json.Linq;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

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
            TakeOffSite = 4,
            LandingSite = 5,
            ParagliderId = 6
        }

        const string apiAddressFlight = "http://localhost:50106/api/v1/flights";
        const string apiAddressSite = "http://localhost:50106/api/v1/sites";
        const string apiAddressParaglider = "http://localhost:50106/api/v1/paragliders";

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
        public async Task<IActionResult> Index(string userSort, string userFilter, string userSecondaryFilter)
        {
            List<SelectListItem> sortItems = LoadSortOptions();
            List<SelectListItem> filterItems = LoadFilterOptions();

            ViewData["sortItems"] = new SelectList(sortItems, "Value", "Text");
            ViewData["filterItems"] = new SelectList(filterItems, "Value", "Text");

            List<FlightDto> flightsDto = await LoadList(userSort, userFilter, userSecondaryFilter);

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
        private static async Task<List<FlightDto>> LoadList(string userSort, string userFilter, string userSecondaryFilter)
        {
            string test = "";
            string test2 = "";
            switch (userFilter)
            {
                case "0":
                   break;
                case "4":
                    test = "TakeOffSiteId";
                    test2 = "1";
                    break;
                case "5":
                    test = "LandingSiteId";
                    test2 = "2";
                    break;
                case "6":
                    test = "ParagliderId";
                    test2 = "3";
                    break;
                default:
                    break;
            }

            List<FlightDto> pFlightsDto;
            using (var httpClient = new HttpClient())
            {
                string fullApiAddress = $"{apiAddressFlight}?SortBy={userSort}&FilterBy={test2}&{test}={userSecondaryFilter}";

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

        //TODO
        // -- Filter by site type
        // -- Get list of take-off sites, landing sites and paragliders
        // -- Call a list from the controller using javascript (?)
        [HttpGet]
        public async Task<JsonResult> FillDropdownMenu(int selectedValue)
        {            
            IEnumerable<string> result;
            //string test = Enum.GetName(typeof(FlightFilter), selectedValue);

            switch (selectedValue)
            {
                case 4:
                case 5:
                    List<SiteDto> dropdownSiteItems;
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync($"{apiAddressSite}?FilterBy={selectedValue}"))
                        {                            
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            dropdownSiteItems = JsonConvert.DeserializeObject<List<SiteDto>>(apiResponse);
                        }
                    }
                    result = dropdownSiteItems.Select(s => (string)s.Name).ToList();
                    break;

                case 6:
                    List<ParagliderDto> dropdownParaItems;
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync($"{apiAddressParaglider}"))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            dropdownParaItems = JsonConvert.DeserializeObject<List<ParagliderDto>>(apiResponse);
                        }
                    }
                    result = dropdownParaItems.Select(p => (string)p.Name).ToList();
                    break;

                default:
                    result = Enumerable.Empty<string>();
                    break;
            }

            List<SelectListItem> secondaryMenu = new List<SelectListItem>();

            foreach (var item in result)
            {
                secondaryMenu.Add(new SelectListItem
                {   
                    Text = item, 
                    Value = item
                });
            }

            return Json(secondaryMenu);
        }
    }
}
