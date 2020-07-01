﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParaglidingProject.Data;
using ParaglidingProject.Data.Repositories;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;

namespace ParaglidingProject.Controllers
{
    public class SubscriptionsController : Controller
    {
        //private readonly ParaglidingClubContext _context;
        private readonly IRepository<Subscription, int> SubscriptionsRepository;

        public SubscriptionsController(IRepository<Subscription, int> repository)
        {
            SubscriptionsRepository = repository;
        }

        //public SubscriptionsController(ParaglidingClubContext context)
        //{
        //    _context = context;
        //}

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {

            IEnumerable<SubscriptionDto> listSubscriptions = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/subscriptions"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listSubscriptions = JsonConvert.DeserializeObject<List<SubscriptionDto>>(apiResponse);
                }
            }
            return View(listSubscriptions);
        }

        // GET: Subscriptions/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions
        //        .Include(p => p.Payments)
        //        .ThenInclude(pi => pi.Pilot)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(y => y.YearID == id);
              
  
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subscription);
        //}

        //// GET: Subscriptions/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Subscriptions/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("YearID,Price")] Subscription subscription)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(subscription);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(subscription);
        //}

        //// GET: Subscriptions/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions.FindAsync(id);
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(subscription);
        //}

        //// POST: Subscriptions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var subscriptionToUpdate = await _context.Subscriptions.FirstOrDefaultAsync(s => s.YearID == id);
        //    if (await TryUpdateModelAsync<Subscription>(
        //        subscriptionToUpdate, "", s => s.YearID, s => s.Price))
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //        "Try again, and if the problem persists, " +
        //        "see your system administrator.");
        //        }
        //    }
        //    return View(subscriptionToUpdate);
        //}

        //// GET: Subscriptions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions
        //        .FirstOrDefaultAsync(m => m.YearID == id);
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subscription);
        //}

        //// POST: Subscriptions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var subscription = await _context.Subscriptions.FindAsync(id);
        //    _context.Subscriptions.Remove(subscription);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SubscriptionExists(int id)
        //{
        //    return _context.Subscriptions.Any(e => e.YearID == id);
        //}

        //public async Task<IActionResult> EditPayment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var payment = await _context.Payments
        //        .Include(p => p.Pilot)
        //        .Include(s => s.Subscription)
        //        .FirstOrDefaultAsync(i => i.ID == id);
        //        //.FindAsync(id);
        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(payment);
        //}

        //[HttpPost, ActionName("EditPayment")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditPaymentPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var paymentToUpdate = await _context.Payments.FirstOrDefaultAsync(p => p.ID == id);
        //    if (await TryUpdateModelAsync<Payment>(
        //        paymentToUpdate, "", p => p.IsPay, p => p.DatePay))
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //        "Try again, and if the problem persists, " +
        //        "see your system administrator.");
        //        }
        //    }
        //    return View(paymentToUpdate);
        //}

        //public async Task<IActionResult> DeletePayment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var payment = await _context.Payments
        //        .Include(p => p.Pilot)
        //        .Include(s => s.Subscription)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(payment);
        //}

        //[HttpPost, ActionName("DeletePayment")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeletePaymentConfirmed(int id)
        //{
        //    var payment = await _context.Payments.FindAsync(id);
        //    _context.Payments.Remove(payment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult CreatePayment(int? id)
        //{
        //    ViewData["SubsciptionID"] = id;
        //    ViewData["PilotID"] = new SelectList(_context.Pilots, "ID", "FirstName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePayment([Bind("PilotID, SubsciptionID, IsPay,DatePay")] Payment payment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(payment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PilotID"] = new SelectList(_context.Pilots, "ID", "FirstName", payment.PilotID);
        //    return View(payment);
        //}
    }
}
