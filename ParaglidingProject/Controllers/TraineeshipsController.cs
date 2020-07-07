using System;
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
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Licenses.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using ParaglidingProject.SL.Core.TraineeShip.NS.Helpers;
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;

namespace ParaglidingProject.Controllers
{
    public class TraineeshipsController : Controller
    {

        // GET: Courses
        public async Task<IActionResult> Index(TraineeShipSorts pTraineeshipSort, TraineeshipFilters filter, TraineeshipSearchs search, string searchInfo)
        {
            IEnumerable<TraineeShipDto> listTraineeships = null;

            string textToSearch = "";
            if(search == TraineeshipSearchs.License)
            {
                textToSearch = "License";
            }
            if(search == TraineeshipSearchs.Price)
            {
                textToSearch = "Price";
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/Traineeships?SortBy={pTraineeshipSort}&FilterBy={filter}&SearchBy={search}&{textToSearch}={searchInfo}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        listTraineeships = JsonConvert.DeserializeObject<List<TraineeShipDto>>(apiResponse);
                    }
                    else
                    {
                        listTraineeships = Enumerable.Empty<TraineeShipDto>();
                    }
                }
            }

            var traineeshipFilter= Enum.GetValues(typeof(TraineeshipFilters))
               .Cast<TraineeshipFilters>()
               .Select(d => new SelectListItem
               {
                   Text = d.ToString(),
                   Value = ((int)d).ToString()
               }).ToList();
            ViewData["traineeshipFilterItems"] = new SelectList(traineeshipFilter, "Value", "Text");

            var traineeshipSearch = Enum.GetValues(typeof(TraineeshipSearchs))
               .Cast<TraineeshipSearchs>()
               .Select(d => new SelectListItem
               {
                   Text = d.ToString(),
                   Value = ((int)d).ToString()
               }).ToList();
            ViewData["traineeshipSearchItems"] = new SelectList(traineeshipSearch, "Value", "Text");

            return View(listTraineeships);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TraineeshipAndPilotsDto viewTraineeship = new TraineeshipAndPilotsDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/Traineeships/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        viewTraineeship = JsonConvert.DeserializeObject<TraineeshipAndPilotsDto>(apiResponse);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(viewTraineeship);
        }

        // GET: Courses/Create
        public async Task<IActionResult> Create()
        {
            ICollection<LicenseDto> licensesDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/licenses/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    licensesDto = JsonConvert.DeserializeObject<ICollection<LicenseDto>>(apiResponse);
                }
            }
            ViewData["LicenseID"] = new SelectList(licensesDto, "LicenseID", "Title");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TraineeShipDto pTraineeshipDto)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pTraineeshipDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"http://localhost:50106/api/v1/Traineeships/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TraineeshipAndPilotsDto viewTraineeship = new TraineeshipAndPilotsDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/Traineeships/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        viewTraineeship = JsonConvert.DeserializeObject<TraineeshipAndPilotsDto>(apiResponse);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }


            ICollection<LicenseDto> licensesDto = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/licenses/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                        licensesDto = JsonConvert.DeserializeObject<ICollection<LicenseDto>>(apiResponse);
                }
            }
            ViewData["LicenseID"] = new SelectList(licensesDto, "LicenseID", "Title");

            return View(viewTraineeship.TraineeshipDto);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TraineeShipDto pTraineeshipDto)
        {
            if (pTraineeshipDto == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pTraineeshipDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:50106/api/v1/Traineeships/", content);
            }

            return RedirectToAction("Index");
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TraineeshipAndPilotsDto viewTraineeship = new TraineeshipAndPilotsDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/Traineeships/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        viewTraineeship = JsonConvert.DeserializeObject<TraineeshipAndPilotsDto>(apiResponse);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(viewTraineeship.TraineeshipDto);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/Traineeships/{id}");
            }
            return RedirectToAction("Index");
        }

    }
}
