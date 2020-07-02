using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;

namespace ParaglidingProject.Controllers
{
    public class ParagliderModelsController : Controller
    {
        // GET: ModelParaglidings
        public async Task<IActionResult> Index()
        {
            IEnumerable<ParagliderModelDto> listParaModels = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/paragliderModels"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listParaModels = JsonConvert.DeserializeObject<List<ParagliderModelDto>>(apiResponse);
                }
            }
            return View(listParaModels);
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
            ParagliderModelDto paragliderModel;
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

        // POST: ModelParaglidings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(ParagliderModelDto pParaModelToModify)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(pParaModelToModify), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:50106/api/v1/paragliderModels/", content);
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
