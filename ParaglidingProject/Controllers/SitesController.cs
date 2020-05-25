using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;

namespace ParaglidingProject.Web.Controllers
{
    public class SitesController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public SitesController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var paraglidingClubContext = _context.Sites
                .Include(s => s.Level)
                .Include(f => f.Flights);

            int biggerFlightsNumber = 0;
            int tinyFlightsNumber = 0;
            List<string> namesSitesBigger = new List<string>();
            List<string> namesSitesTiny = new List<string>();
          
           foreach(var item in paraglidingClubContext)
           {
                var flights = _context.Flights.Where(f => f.LandingSiteID == item.ID);
                var totalFlights = flights.Count();
                
                if(totalFlights >= biggerFlightsNumber)
                {
                    if(totalFlights == biggerFlightsNumber)
                    {
                        namesSitesBigger.Add(item.Name);
                    }
                    else
                    {
                        namesSitesBigger.Clear();
                        namesSitesBigger.Add(item.Name);
                    }
                    biggerFlightsNumber = totalFlights;
                }
                else
                {
                    
                    if(tinyFlightsNumber == 0)
                    {
                       tinyFlightsNumber = totalFlights;  
                    }
                    if (totalFlights == tinyFlightsNumber)
                    {
                        namesSitesTiny.Add(item.Name);
                    }

                   if (totalFlights < tinyFlightsNumber)
                   {
                            namesSitesTiny.Clear();
                            namesSitesTiny.Add(item.Name);
                    }
                    
                    tinyFlightsNumber = totalFlights;
                }
           }

            ViewData["BiggerFlightsData"] = namesSitesBigger;
            ViewData["TinyFlightsData"] = namesSitesTiny;
            return View(await paraglidingClubContext.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .Include(s => s.Level)
                .Include(f => f.Flights)
                .ThenInclude(p => p.Pilot)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["LevelID"] = new SelectList(_context.Levels, "ID", "ID");
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,OrientationLanding,OrientationTakeOff,AltitudeTakeOff,FlightType,LevelID")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevelID"] = new SelectList(_context.Levels, "ID", "ID", site.LevelID);
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["LevelID"] = new SelectList(_context.Levels, "ID", "ID", site.LevelID);
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,OrientationLanding,OrientationTakeOff,AltitudeTakeOff,FlightType,LevelID")] Site site)
        {
            if (id != site.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.ID))
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
            ViewData["LevelID"] = new SelectList(_context.Levels, "ID", "ID", site.LevelID);
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .Include(s => s.Level)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.ID == id);
        }

        public async Task<IActionResult> DetailsFlight(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Flights
                .Include(p => p.Paraglider)
                .Include(p => p.Pilot)
                .Include(s => s.LandingSite)
                 .Include(s => s.TakeOffSite)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }
    }
}
