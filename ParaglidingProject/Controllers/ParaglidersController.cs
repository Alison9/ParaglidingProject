using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;

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
        public IActionResult Create()
        {
            ViewData["ModelParaglidingID"] = new SelectList(_context.ParagliderModels, "ID", "ID");
            return View();
        }

        // POST: Paraglidings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateOfCommissioning,DateOfLastRevision,ModelParaglidingID")] Paraglider paragliding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paragliding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelParaglidingID"] = new SelectList(_context.ParagliderModels, "ID", "ID", paragliding.ParagliderModelID);
            return View(paragliding);
        }

        // GET: Paraglidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragliding = await _context.Paragliders.FindAsync(id);
            if (paragliding == null)
            {
                return NotFound();
            }
            ViewData["ModelParaglidingID"] = new SelectList(_context.ParagliderModels, "ID", "ID", paragliding.ParagliderModelID);
            return View(paragliding);
        }

        // POST: Paraglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateOfCommissioning,DateOfLastRevision,ModelParaglidingID")] Paraglider paragliding)
        {
            if (id != paragliding.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paragliding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParaglidingExists(paragliding.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelParaglidingID"] = new SelectList(_context.ParagliderModels, "ID", "ID", paragliding.ParagliderModelID);
            return View(paragliding);
        }

        // GET: Paraglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragliding = await _context.Paragliders
                .Include(p => p.ParagliderModel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paragliding == null)
            {
                return NotFound();
            }

            return View(paragliding);
        }

        // POST: Paraglidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paragliding = await _context.Paragliders.FindAsync(id);
            _context.Paragliders.Remove(paragliding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParaglidingExists(int id)
        {
            return _context.Paragliders.Any(e => e.ID == id);
        }
    }
}
