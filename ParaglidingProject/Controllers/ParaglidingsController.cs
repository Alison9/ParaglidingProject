using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;

namespace ParaglidingProject.Controllers
{
    public class ParaglidingsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public ParaglidingsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Paraglidings
        public async Task<IActionResult> Index()
        {
            var paraglidingClubContext = _context.Paragliders.Include(p => p.ParagliderModel);
            return View(await paraglidingClubContext.ToListAsync());
        }

        // GET: Paraglidings/Details/5
        public async Task<IActionResult> Details(int? id)
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
