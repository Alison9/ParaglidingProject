using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;

namespace ParaglidingProject.Controllers
{
    public class PilotsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public PilotsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Pilots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pilots.ToListAsync());


        }

        // GET: Pilots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _context.Pilots
                .Include(f => f.Flights)
                .Include(o => o.Obtainings)
                    .ThenInclude(li => li.License)
                       .ThenInclude(le =>le.Level)
                .FirstOrDefaultAsync(m => m.ID == id);

            var flight = _context.Flights.Where(f => f.PilotID == id);
            var collectionflight = flight.Count();
            ViewData["collectionflight"] = collectionflight;
            TimeSpan flightTime = new TimeSpan();

            if (pilot == null)
            {
                return NotFound();
            }

            foreach (var item in flight)
            {
                TimeSpan FlightDuration = (item.FlightEnd) - (item.FlightStart);
                        ViewData["flightDuration"] = FlightDuration;
                        flightTime += FlightDuration;
                        ViewData["flightTimeTotal"] = flightTime;
                
            }
            
            return View(pilot);
            
            
        }

        // GET: Pilots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pilots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Adress,PhoneNumber,Weight,Position,IsActif")] Pilot pilot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pilot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Pas bien !");
            }
            return View(pilot);
        }

        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _context.Pilots.FindAsync(id);
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

            var pilotToUpdate = await _context.Pilots.FindAsync(id);
            if (await TryUpdateModelAsync<Pilot>(pilotToUpdate, "", s => s.FirstName, s => s.LastName, s => s.Adress,
               s => s.PhoneNumber, s => s.Weight, s => s.Position, s => s.IsActif))
            {
                if (ModelState.IsValid)

                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
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
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _context.Pilots
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pilot == null)
            {
                return NotFound();
            }

            return View(pilot);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pilot = await _context.Pilots.FindAsync(id);

            if(pilot == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try 
            {
                _context.Pilots.Remove(pilot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException )
            {
                
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool PilotExists(int id)
        {
            return _context.Pilots.Any(e => e.ID == id);
        }
    }
}
