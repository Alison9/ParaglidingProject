﻿using System;
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
using ParaglidingProject.Data.Repositories;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Subscription.NS.Helpers;
using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;

namespace ParaglidingProject.Controllers
{
    public class SubscriptionsController : Controller
    {

        // GET: Subscriptions
        public async Task<IActionResult> Index(SubscriptionSorts pSortSubscription = SubscriptionSorts.noSubscriptionOrder)
        {
            IEnumerable<SubscriptionDto> listSubscriptions = null;
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/subscriptions?OrderBy={pSortSubscription}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listSubscriptions = JsonConvert.DeserializeObject<List<SubscriptionDto>>(apiResponse);
                }
            }
            return View(listSubscriptions);
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubscriptionAndPilotsDto viewSubscription = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/subscriptions/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        viewSubscription = JsonConvert.DeserializeObject<SubscriptionAndPilotsDto>(apiResponse);
                    }
                    else
                    {
                        //Redirect or send empty
                        viewSubscription = new SubscriptionAndPilotsDto();
                    }
                }
            }
            return View(viewSubscription);
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
        public async Task<IActionResult> Create(SubscriptionDto pSubscriptionDto)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pSubscriptionDto), Encoding.UTF8, "application/json");
                var response =  await httpClient.PostAsync($"http://localhost:50106/api/v1/subscriptions/", content);
            }
            return RedirectToAction("Index");
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubscriptionAndPilotsDto viewSubscription = null;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/subscriptions/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if(response.StatusCode != HttpStatusCode.OK)
                    {
                        return NotFound();
                    }
                    viewSubscription = JsonConvert.DeserializeObject<SubscriptionAndPilotsDto>(apiResponse);
                }
            }

            return View(viewSubscription.SubscriptionDto);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubscriptionDto pSubscriptionDto)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"http://localhost:50106/api/v1/subscriptions";
                var content = new StringContent(JsonConvert.SerializeObject(pSubscriptionDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);
            }

            return RedirectToAction("Index");
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubscriptionAndPilotsDto viewSubscription = null;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/subscriptions/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return NotFound();
                    }
                    viewSubscription = JsonConvert.DeserializeObject<SubscriptionAndPilotsDto>(apiResponse);
                }
            }

            return View(viewSubscription.SubscriptionDto);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/subscriptions/{id}");
            }

            return RedirectToAction("Index");
        }
    }
}
