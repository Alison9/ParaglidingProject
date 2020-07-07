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
using Microsoft.AspNetCore.JsonPatch;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Site.NS.Helpers;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

namespace ParaglidingProject.Controllers
{
    public class ParagliderModelsController : Controller
    {
        // GET: ModelParaglidings
        public async Task<IActionResult> Index(ParagliderModelsSorts pParagliderModelSort,
            PargliderModelFilters filter,string filterInfo,
            ParagliderModelSearch search,string searchInfo)
        {
            IEnumerable<ParagliderModelDto> listParagliderModels = null;
            string textToSort = "";
            string textToSearch = "";
            if(filter == PargliderModelFilters.Heavyweight)
            {
                textToSort = "Heavyweight";
            }

            if (filter == PargliderModelFilters.Pilotweight)
            {
                textToSort = "Pilotweight";
            }

            if (search == ParagliderModelSearch.ApprovalNumber)
            {
                textToSearch = "ApprovalNumber";
            }
            if(search == ParagliderModelSearch.Size)
            {
                textToSearch = "Size";
            }
            using (var httpClient = new HttpClient())
            {
                string FulApiUrl = $"http://localhost:50106/api/v1/paragliderModels?SortBy={pParagliderModelSort}&FilterBy={filter}&{textToSort}={filterInfo}&SearchBy={search}&{textToSearch}={searchInfo}";
                using (var response = await httpClient.GetAsync(FulApiUrl))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        listParagliderModels = JsonConvert.DeserializeObject<List<ParagliderModelDto>>(apiResponse);
                    }
                    else
                    {
                        listParagliderModels = Enumerable.Empty<ParagliderModelDto>();
                    }
                }
            }

            var paraglidermodelFilters = Enum.GetValues(typeof(PargliderModelFilters))
                .Cast<PargliderModelFilters>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();
            ViewData["paraglidermodelFilterItems"] = new SelectList(paraglidermodelFilters, "Value", "Text");

            var paraglidermodelSearch = Enum.GetValues(typeof(ParagliderModelSearch))
                .Cast<ParagliderModelSearch>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();
            ViewData["paraglidermodelSearchItems"] = new SelectList(paraglidermodelSearch, "Value", "Text");

            return View(listParagliderModels);
        }

        // GET: ModelParaglidings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParagliderModelAndParagliders ViewParagliderModel = new ParagliderModelAndParagliders();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewParagliderModel = JsonConvert.DeserializeObject<ParagliderModelAndParagliders>(apiResponse);
                }
            }
            return View(ViewParagliderModel);
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
        public async Task<IActionResult> Create(ParagliderModelDto modelParagliding)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(modelParagliding),Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/paragliderModels/", content);
            }
            return RedirectToAction("Index");
        }

        // GET: ModelParaglidings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ParagliderModelDto paragliderModel = null;
            ParagliderModelAndParagliders pmAndpDto = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pmAndpDto = JsonConvert.DeserializeObject<ParagliderModelAndParagliders>(apiResponse);
                    paragliderModel = pmAndpDto.ParagliderModelDto;
                }
            }

            return View(paragliderModel);
        }

        // POST: ModelParaglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(ParagliderModelDto pParaModelToModify)
        {
            ParagliderModelPatchDto paragliderModelAsPatchDto = new ParagliderModelPatchDto
            {
                MaxWeightPilot = pParaModelToModify.MaxWeightPilot,
                MinWeightPilot = pParaModelToModify.MinWeightPilot
            };
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(paragliderModelAsPatchDto), Encoding.UTF8, "application/json-patch+json");
                var response = await httpClient.PatchAsync($"http://localhost:50106/api/v1/paragliderModels/{pParaModelToModify.ID}", content);
            }
            return RedirectToAction("Index");
        }

        // GET: ModelParaglidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var paragliderModel = new ParagliderModelDto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:50106/api/v1/paragliderModels/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paragliderModel = JsonConvert.DeserializeObject<ParagliderModelDto>(apiResponse);
                }
            }
            return View(paragliderModel);
        }

        // POST: ModelParaglidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:50106/api/v1/paragliderModels/{id}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateParagliding(int? id)
        {
            ViewData["ModelParagliding"] = id;
            return View();
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
