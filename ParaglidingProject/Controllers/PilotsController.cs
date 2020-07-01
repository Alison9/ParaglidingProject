using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.Controllers
{
    public class PilotsController : Controller
    {
        const string apiAddressPilot = "http://localhost:50106/api/v1/pilots";
        const string apiAddressRole = "http://localhost:50106/api/v1/roles";
        private readonly ParaglidingClubContext _context;

        public PilotsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Pilots
        public async Task<IActionResult> Index()
        {
            List<PilotDto> pilotsDto;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiAddressPilot))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pilotsDto = JsonConvert.DeserializeObject<List<PilotDto>>(apiResponse);
                }
            }

            List<Pilot> pilots = await _context.Pilots.ToListAsync();

            //Join sur forme de méthode
            //List<Pilot> joinedPilots = pilots.Join<Pilot, PilotDto, int, Pilot>(pilotsDto, p => p.ID, pdto => pdto.PilotId, (p, pdto) => p).ToList();

            //Join sur forme de query
            List<Pilot> joinedPilots2 = (from p in pilots
                                         join pdo in pilotsDto
                                         on p.ID equals pdo.PilotId
                                         select p).ToList();

            //return View(await _context.Pilots.ToListAsync());
            return View(joinedPilots2);
        }

        // POST: Pilots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PilotDto pilotDto;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiAddressPilot + $"/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pilotDto = JsonConvert.DeserializeObject<PilotDto>(apiResponse);
                }
            }

            return View(pilotDto);
        }

        // GET: Pilots/Create
        public IActionResult Create()
        {
            ViewData["PositionID"] = new SelectList(_context.Roles, "ID", "Name");
            return View();
        }

        // POST: Pilots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pilot pilot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pilot receivedPilot = new Pilot();
                    using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(pilot), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync(apiAddressPilot, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            receivedPilot = JsonConvert.DeserializeObject<Pilot>(apiResponse);
                        }
                    }
                    return RedirectToAction("Index", receivedPilot);
                }
                else {
                    return View();
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Pas bien !");
                return View(ModelState);
            }
            
        }

        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await FillFormByPilotId(id);
        }

        private async Task<IActionResult> FillFormByPilotId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pilot pilot;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiAddressPilot + $"/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pilot = JsonConvert.DeserializeObject<Pilot>(apiResponse);
                }
            }

            if (pilot == null)
            {
                return NotFound();
            }
            return View(pilot);
        }

        // POST: Pilots/Edit/5
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

            Pilot pilotToUpdate;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiAddressPilot + $"/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pilotToUpdate = JsonConvert.DeserializeObject<Pilot>(apiResponse);
                }
            }

            if (pilotToUpdate == null)
            {
                return BadRequest();
            }
            
            if (await TryUpdateModelAsync<Pilot>(pilotToUpdate, "", s => s.FirstName, s => s.LastName, s => s.Address,
               s => s.PhoneNumber, s => s.Weight))
            {
                if (ModelState.IsValid)

                {
                    try
                    {
                        Pilot receivedPilot;
                        using (var httpClient = new HttpClient())
                        {
                            StringContent content = new StringContent(JsonConvert.SerializeObject(pilotToUpdate), Encoding.UTF8, "application/json");
                            using (var response = await httpClient.PutAsync(apiAddressPilot + $"/{id}", content))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                receivedPilot = JsonConvert.DeserializeObject<Pilot>(apiResponse);
                            }
                        }
                        return RedirectToAction(nameof(Index), receivedPilot);
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }
                }
            }
            return View(pilotToUpdate);
        }
        // GET: Pilots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return await FillFormByPilotId(id);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(apiAddressPilot + $"/{id}");
            }
            return RedirectToAction(nameof(Index));
        }

        /*Get CreateFligth*/ 
        public IActionResult CreateFlight(int? id)
        {
            var pilot = _context.Pilots
                .Where(p => p.ID == id).FirstOrDefault();

            ViewData["FirstName"] = pilot.FirstName;
            ViewData["LastName"] = pilot.LastName;
            ViewData["PilotID"] = pilot.ID;
            ViewData["ParaglidingID"] = new SelectList(_context.Paragliders, "ID", "ID");
            ViewData["SiteID"] = new SelectList(_context.Sites, "ID", "Name");

            return View("CreateFlight");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlight([Bind("PilotID, FlightDate, FlightStart, FlightEnd, ParaglidingID, SiteID, Pilot")] Flight flight)
        {
            var pilot = _context.Pilots.Where(p => p.ID  == flight.PilotID).FirstOrDefault();
            var paragliding = _context.Paragliders.Where(pa => pa.ID == flight.ParagliderID).FirstOrDefault();
            var modelparagliding = _context.ParagliderModels.Where(m => m.ID == paragliding.ParagliderModelID).FirstOrDefault();
            if(pilot.Weight > modelparagliding.MaxWeightPilot || pilot.Weight < modelparagliding.MinWeightPilot)
            {
                ModelState.AddModelError("", "Parapente pas adapté au pilote");
            }

            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View("CreateFlight");
        }
    }
}
