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
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

namespace ParaglidingProject.Web.Controllers
{
    public class SitesController : Controller
    {
        // GET: Sites
        public async Task<IActionResult> Index()
        {
            IEnumerable<SiteDto> listSites = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/sites"))
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
            SiteDto siteDto = null;
            ICollection<FlightDto> flightsDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/sites/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    siteDto = JsonConvert.DeserializeObject<SiteDto>(apiResponse);
                }
            }
            int filterType = 1;
            string filterTypeName = "TakeOffSiteId";
            if (siteDto.SiteType == Enumeration.Enm_SiteType.Landing)
            {
                filterType = 2;
                filterTypeName = "LandingSiteId";
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/flights?FilterBy={filterType}&{filterTypeName}={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        flightsDto = JsonConvert.DeserializeObject<ICollection<FlightDto>>(apiResponse);
                }
            }
            viewSite.SiteDto = siteDto;
            viewSite.FlightsDto = flightsDto;

            return View(viewSite);

        }

        // GET: Sites/Create
        public async Task<IActionResult> Create(int pSiteType)
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
            if (id == null)
            {
                return NotFound();
            }

            
            return View();
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

            
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            return View();
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsFlight(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
