using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;

namespace ParaglidingProject.Controllers
{
    public class ParaglidersController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public ParaglidersController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Paraglidings
        public async Task<IActionResult> Index()
        {
            IEnumerable<ParagliderDto> listParagliders = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/paragliders"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listParagliders = JsonConvert.DeserializeObject<List<ParagliderDto>>(apiResponse);
                }
            }
            return View(listParagliders);
        }

        // GET: Paraglidings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ParagliderAndFlightsDto ViewParaglider = new ParagliderAndFlightsDto();

            ICollection<FlightDto> flightsDto = null;
            ParagliderDto paragliderDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderDto = JsonConvert.DeserializeObject<ParagliderDto>(apiResponse);
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/flights?FilterBy=3&ParagliderId={paragliderDto.ParagliderId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        flightsDto = JsonConvert.DeserializeObject<ICollection<FlightDto>>(apiResponse);
                }
            }

            ViewParaglider.ParagliderDto = paragliderDto;
            ViewParaglider.FlightsDto = flightsDto;

            return View(ViewParaglider);
        }

        // GET: Paraglidings/Create
        public async Task<IActionResult> Create()
        {
            ICollection<ParagliderModelDto> paragliderModelsDto = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        paragliderModelsDto = JsonConvert.DeserializeObject<ICollection<ParagliderModelDto>>(apiResponse);
                }
            }
            
            ViewData["ParaglidersModels"] = new SelectList(paragliderModelsDto, "ID", "ID");
            return View();
        }

        // POST: Paraglidings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParagliderDto pParagliderDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pParagliderDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/paragliders/", content);
            }

            return RedirectToAction("Index");

        }

        // GET: Paraglidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ICollection<ParagliderModelDto> paragliderModelsDto = null;
            ParagliderDto paragliderDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderDto = JsonConvert.DeserializeObject<ParagliderDto>(apiResponse);
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        paragliderModelsDto = JsonConvert.DeserializeObject<ICollection<ParagliderModelDto>>(apiResponse);
                }
            }

            ViewData["ParaglidersModels"] = new SelectList(paragliderModelsDto, "ID", "ID");

            return View(paragliderDto);
        }

        // POST: Paraglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParagliderDto pParagliderDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pParagliderDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:50106/api/v1/paragliders/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Paraglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var paragliderDto = new ParagliderDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderDto = JsonConvert.DeserializeObject<ParagliderDto>(apiResponse);
                }
            }
            return View(paragliderDto);
        }

        // POST: Paraglidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/paragliders/{id}");
            }
            return RedirectToAction("Index");
        }

        private bool ParaglidingExists(int id)
        {
            return _context.Paragliders.Any(e => e.ID == id);
        }
    }
}
