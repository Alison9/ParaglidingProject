using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Paraglider.NS.Helpers;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using static ParaglidingProject.SL.Core.Paraglider.NS.Helpers.ParagliderSortHelper;

namespace ParaglidingProject.Controllers
{
    public class ParaglidersController : Controller
    {
        // GET: Paraglidings
        public async Task<IActionResult> Index(ParaglidersFilters filter, ParagliderSort sort,string paraglidersortInfo, string paragliderfilterInfo, ParaglidersSearch search, string ParagliderserchInfo)
        {
            IEnumerable<ParagliderDto> listParagliders = null;
            string textToSort = "";
            string textTosearch = "";
            string textTofilter = "";

            // to filter
            if(filter == ParaglidersFilters.CommissionDate)
            {
                textTofilter = "CommissionDate";
            }
           
            if (filter == ParaglidersFilters.ModelParaglider)
            {
                textTofilter = "ParagliderModelId";
            }
            if (filter == ParaglidersFilters.RevisionDate)
            {
                textTofilter = "LastRevisionDate";
            }
            // to search
            if(search == ParaglidersSearch.LastRevisionDate)
            {
                textTosearch = "DateLastRevision";
            }
            if (search == ParaglidersSearch.Name)
            {
                textTosearch = "Name";
            }
            // sort
            if (sort == ParagliderSort.CommissionDate)
            {
                textToSort = "CommissionDate";
            }

            if (sort== ParagliderSort.ModelParaglider)
            {
                textToSort = "ParagliderModelId";
            }
            if (sort == ParagliderSort.RevisionDate)
            {
                textToSort = "LastRevisionDate";
            }


            using (var httpClient = new HttpClient())
            {
                string urlfullpath = $"http://localhost:50106/api/v1/paragliders?SortBy={sort}&{textToSort}={paraglidersortInfo}&FilterBy={filter}&{textTofilter}={paragliderfilterInfo}&SearchBy={search}&{textTosearch}={ParagliderserchInfo}";
                using (var response = await httpClient.GetAsync(urlfullpath))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        listParagliders = JsonConvert.DeserializeObject<List<ParagliderDto>>(apiResponse);
                    }
                    else
                    {
                        listParagliders = Enumerable.Empty<ParagliderDto>();
                    }
                }
            }
            //to make filter
            var paragliderFilter = Enum.GetValues(typeof(ParaglidersFilters))
              .Cast<ParaglidersFilters>()
                .Select(p => new SelectListItem
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                }).ToList();

            ViewData["paragliderFilterItems"] = new SelectList(paragliderFilter, "Value", "Text");
        // To make search

        var paragliderSearch = Enum.GetValues(typeof(ParaglidersSearch))
               .Cast<ParaglidersSearch>()
               .Select(d => new SelectListItem
               {
                   Text = d.ToString(),
                   Value = ((int)d).ToString()
               }).ToList();
        ViewData["paragliderSearchItems"] = new SelectList(paragliderSearch, "Value", "Text");
            //to sort

            var paragliderSort = Enum.GetValues(typeof(ParagliderSort))
               .Cast<ParagliderSort>()
               .Select(d => new SelectListItem
               {
                   Text = d.ToString(),
                   Value = ((int)d).ToString()
               }).ToList();
            ViewData["paragliderSortItems"] = new SelectList(paragliderSort, "Value", "Text");




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

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewParaglider = JsonConvert.DeserializeObject<ParagliderAndFlightsDto>(apiResponse);
                }
            }
            return View(ViewParaglider);
        }

        // GET: Paraglidings/Create
        public async Task<IActionResult> Create()
        {
            ICollection<ParagliderModelDto> paragliderModelsDto = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        paragliderModelsDto = JsonConvert.DeserializeObject<ICollection<ParagliderModelDto>>(apiResponse);
                }
            }
            
            ViewData["ParaglidersModels"] = new SelectList(paragliderModelsDto, "ID", "ID");
            return View();
        }

        // POST: Paraglidings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParagliderDto pParagliderDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pParagliderDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/paragliders/", content);
            }

            return RedirectToAction("Index");

        }

        // GET: Paraglidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ICollection<ParagliderModelDto> paragliderModelsDto = null;
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
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        paragliderModelsDto = JsonConvert.DeserializeObject<ICollection<ParagliderModelDto>>(apiResponse);
                }
            }

            ViewData["ParaglidersModels"] = new SelectList(paragliderModelsDto, "ID", "ID");

            return View(paragliderDto);
        }

        // POST: Paraglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParagliderDto pParagliderDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pParagliderDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:50106/api/v1/paragliders/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Paraglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var paragliderDto = new ParagliderDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliders/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderDto = JsonConvert.DeserializeObject<ParagliderDto>(apiResponse);
                }
            }
            return View(paragliderDto);
        }

        // POST: Paraglidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/paragliders/{id}");
            }
            return RedirectToAction("Index");
        }
    }
}
