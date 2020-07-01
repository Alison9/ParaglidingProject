using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;

namespace ParaglidingProject.Controllers
{
    public class ParagliderModelsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public ParagliderModelsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: ModelParaglidings
        public async Task<IActionResult> Index()
        {
            IEnumerable<ParagliderModelDto> listParaModels = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/paragliderModels"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listParaModels = JsonConvert.DeserializeObject<List<ParagliderModelDto>>(apiResponse);
                }
            }
            return View(listParaModels);
        }

        // GET: ModelParaglidings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ParagliderModelAndParagliders ViewParagliderModel = new ParagliderModelAndParagliders();

            ICollection<ParagliderDto> paragliderDto = null;
            ParagliderModelDto paragliderModel = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderModel = JsonConvert.DeserializeObject<ParagliderModelDto>(apiResponse);
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders?FilterBy=4&ParagliderModelId={paragliderModel.ID}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if(response.StatusCode == HttpStatusCode.OK)
                        paragliderDto = JsonConvert.DeserializeObject<ICollection<ParagliderDto>>(apiResponse);
                }
            }

            ViewParagliderModel.ParagliderModelDto = paragliderModel;
            ViewParagliderModel.ParagliderDto = paragliderDto;

            return View(ViewParagliderModel);
        }

        // GET: ModelParaglidings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelParaglidings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParagliderModel modelParagliding)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(modelParagliding),Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/paragliderModels/", content);
            }
            return RedirectToAction("Index");
        }

        // GET: ModelParaglidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelParagliding = await _context.ParagliderModels.FindAsync(id);
            if (modelParagliding == null)
            {
                return NotFound();
            }
            return View(modelParagliding);
        }

        // POST: ModelParaglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var modelParaglidingToUpdate = await _context.ParagliderModels.FirstOrDefaultAsync(p => p.ID == id);
            if (await TryUpdateModelAsync<ParagliderModel>(
                modelParaglidingToUpdate, "", p => p.Size, p => p.ApprovalDate, p => p.ApprovalNumber, p => p.MaxWeightPilot, p => p.MinWeightPilot))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
                }
            }
            return View(modelParaglidingToUpdate);

            //if (id != modelParagliding.ID)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(modelParagliding);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ModelParaglidingExists(modelParagliding.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(modelParagliding);
        }

        // GET: ModelParaglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelParagliding = await _context.ParagliderModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (modelParagliding == null)
            {
                return NotFound();
            }

            return View(modelParagliding);
        }

        // POST: ModelParaglidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelParagliding = await _context.ParagliderModels.FindAsync(id);
            _context.ParagliderModels.Remove(modelParagliding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelParaglidingExists(int id)
        {
            return _context.ParagliderModels.Any(e => e.ID == id);
        }

        public IActionResult CreateParagliding(int? id)
        {
            ViewData["ModelParagliding"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateParagliding([Bind("DateOfCommissioning, DateOfLastRevision, ModelParaglidingID")] Paraglider paragliding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paragliding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paragliding);
        }

        public async Task<IActionResult> DeleteParagliding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["ModelParagliding"] = id;

            var paragliding = await _context.Paragliders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paragliding == null)
            {
                return NotFound();
            }

            return View(paragliding);
        }

        [HttpPost, ActionName("DeleteParagliding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParaglidingConfirmed(int id)
        {
            var paragliding = await _context.Paragliders.FindAsync(id);
            _context.Paragliders.Remove(paragliding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditParagliding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragliding = await _context.Paragliders
                .FirstOrDefaultAsync(i => i.ID == id);
            //.FindAsync(id);
            if (paragliding == null)
            {
                return NotFound();
            }
            ViewData["ModelParaglidingID"] = new SelectList(_context.ParagliderModels, "ID", "ID");
            return View(paragliding);
        }

        [HttpPost, ActionName("EditParagliding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParaglidingPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paraglidingToUpdate = await _context.Paragliders.FirstOrDefaultAsync(p => p.ID == id);
            
            if (await TryUpdateModelAsync<Paraglider>(
                paraglidingToUpdate, "", p => p.CommissioningDate, p => p.LastRevisionDate, p => p.ParagliderModelID))
            {
                try
                {
                   
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
                }
            }

            return View(paraglidingToUpdate);
        }

        public async Task<IActionResult> DetailsParagliding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragliding = await _context.Paragliders
                .Include(p => p.ParagliderModelID)
                .Include(f => f.Flights)
                .ThenInclude(p => p.Pilot)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paragliding == null)
            {
                return NotFound();
            }

            //var flights = _context.Flights.Where(f => f.ParagliderID == id);
            //ViewData["flightCount"] = flights.Count();
            //TimeSpan flightTime = new TimeSpan();
            //foreach (var item in flights)
            //{
            //    var flightDuration = item.FlightEnd - item.FlightStart;
            //    flightTime  +=  flightDuration;
                

            //}

            //ViewData["flightTime"] = flightTime;

            return View(paragliding);
        }

        public async Task<IActionResult> DetailsFlight(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(p => p.LandingSite)
               // .Include(p => p.TakeOffSite)
                .Include(f => f.Pilot)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }
    }
}
