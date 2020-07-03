using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Site.NS.Helpers;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

namespace ParaglidingProject.Web.Controllers
{
    public class SitesController : Controller
    {

        // GET: Sites
        public async Task<IActionResult> Index(SitesSorts pSiteSort)
        {
            IEnumerable<SiteDto> listSites = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/sites?SortBy={pSiteSort}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listSites = JsonConvert.DeserializeObject<List<SiteDto>>(apiResponse);
                }
            }
            return View(listSites);
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteAndFlightsDto viewSite = new SiteAndFlightsDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/sites/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    viewSite = JsonConvert.DeserializeObject<SiteAndFlightsDto>(apiResponse);
                }
            }

            return View(viewSite);

        }

        // GET: Sites/Create
        public async Task<IActionResult> Create(TypeSite pSiteType)
        {
            ICollection<LevelDto> levelsDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/levels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        levelsDto = JsonConvert.DeserializeObject<ICollection<LevelDto>>(apiResponse);
                }
            }
            ViewData["SiteType"] = pSiteType;
            ViewData["LevelID"] = new SelectList(levelsDto, "LevelID", "Name");
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteDto pSiteDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pSiteDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/sites/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ICollection<LevelDto> levelsDto = null;
            if (id == null)
            {
                return NotFound();
            }
            SiteAndFlightsDto viewSite = new SiteAndFlightsDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/sites/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    viewSite = JsonConvert.DeserializeObject<SiteAndFlightsDto>(apiResponse);
                }
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/levels/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        levelsDto = JsonConvert.DeserializeObject<ICollection<LevelDto>>(apiResponse);
                }
            }
            ViewData["LevelID"] = new SelectList(levelsDto, "LevelID", "Name");
            return View(viewSite);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiteDto siteDto)
        {
            if (siteDto == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(siteDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:50106/api/v1/sites/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteAndFlightsDto viewSite = new SiteAndFlightsDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/sites/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    viewSite = JsonConvert.DeserializeObject<SiteAndFlightsDto>(apiResponse);
                }
            }

            return View(viewSite.SiteDto);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/sites/{id}");
            }
            return RedirectToAction("Index");
        }
    }
}
