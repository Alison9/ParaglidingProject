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
    public class ModelParaglidingsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public ModelParaglidingsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: ModelParaglidings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelParaglidings.ToListAsync());
        }

        // GET: ModelParaglidings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelParagliding = await _context.ModelParaglidings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (modelParagliding == null)
            {
                return NotFound();
            }

            return View(modelParagliding);
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
        public async Task<IActionResult> Create([Bind("ID,HeightParagliding,MaxWeightPilot,MinWeightPilot,AprovalNumber,AprovalDate")] ModelParagliding modelParagliding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelParagliding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelParagliding);
        }

        // GET: ModelParaglidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelParagliding = await _context.ModelParaglidings.FindAsync(id);
            if (modelParagliding == null)
            {
                return NotFound();
            }
            return View(modelParagliding);
        }

        // POST: ModelParaglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HeightParagliding,MaxWeightPilot,MinWeightPilot,AprovalNumber,AprovalDate")] ModelParagliding modelParagliding)
        {
            if (id != modelParagliding.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelParagliding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelParaglidingExists(modelParagliding.ID))
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
            return View(modelParagliding);
        }

        // GET: ModelParaglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelParagliding = await _context.ModelParaglidings
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
            var modelParagliding = await _context.ModelParaglidings.FindAsync(id);
            _context.ModelParaglidings.Remove(modelParagliding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelParaglidingExists(int id)
        {
            return _context.ModelParaglidings.Any(e => e.ID == id);
        }
    }
}
