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
    public class SubscriptionsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public SubscriptionsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Subscriptions.OrderByDescending(s => s.YearID).ToListAsync());
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(p => p.Payments)
                .ThenInclude(pi => pi.Pilot)
                .AsNoTracking()
                .FirstOrDefaultAsync(y => y.YearID == id);
              
  
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YearID,Price")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
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
            var subscriptionToUpdate = await _context.Subscriptions.FirstOrDefaultAsync(s => s.YearID == id);
            if (await TryUpdateModelAsync<Subscription>(
                subscriptionToUpdate, "", s => s.YearID, s => s.Price))
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

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(subscription);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!SubscriptionExists(subscription.YearID))
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
            return View(subscriptionToUpdate);
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(m => m.YearID == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.YearID == id);
        }

        public async Task<IActionResult> EditPayment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Pilot)
                .Include(s => s.Subscription)
                .FirstOrDefaultAsync(i => i.ID == id);
                //.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        [HttpPost, ActionName("EditPayment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPaymentPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paymentToUpdate = await _context.Payments.FirstOrDefaultAsync(p => p.ID == id);
            if (await TryUpdateModelAsync<Payment>(
                paymentToUpdate, "", p => p.IsPay, p => p.DatePay))
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
            return View(paymentToUpdate);
        }

        public async Task<IActionResult> DeletePayment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Pilot)
                .Include(s => s.Subscription)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("DeletePayment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePaymentConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
