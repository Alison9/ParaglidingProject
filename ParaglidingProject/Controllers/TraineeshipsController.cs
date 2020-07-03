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
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;

namespace ParaglidingProject.Controllers
{
    public class TraineeshipsController : Controller
    {
        private readonly ParaglidingClubContext _context;

        public TraineeshipsController(ParaglidingClubContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            IEnumerable<TraineeShipDto> listTraineeships = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50106/api/v1/Traineeships"))
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
                var response = await httpClient.PostAsync("http://localhost:50106/api/v1/Traineeships/", content);
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

            var course = await _context.Traineeships.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["LicenseID"] = new SelectList(_context.Licenses, "ID", "ID", course.LicenseID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StartDate,EndDate,CoursePrice,LicenseID")] Traineeship course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
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
            ViewData["LicenseID"] = new SelectList(_context.Licenses, "ID", "ID", course.LicenseID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Traineeships
                .Include(c => c.License)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Traineeships.FindAsync(id);
            _context.Traineeships.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Traineeships.Any(e => e.ID == id);
        }
    }
}
