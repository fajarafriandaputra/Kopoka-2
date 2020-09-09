using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrialDev.Services;
using TrialDev.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TrialDev.Controllers
{
    public class JobVacanciesController : Controller
    {
        private readonly IJobVacancy _IjobVacancy;
        public JobVacanciesController(IJobVacancy IjobVacancy)
        {
            _IjobVacancy = IjobVacancy;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobVacancyDTO jobVacancyDTO)
        {
            if (ModelState.IsValid)
            {
                await _IjobVacancy.Insert(jobVacancyDTO);
                await _IjobVacancy.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(jobVacancyDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobVacancyDTO jobVacancyDTO)
        {
            if (ModelState.IsValid)
            {
                await _IjobVacancy.Update(jobVacancyDTO);
                await _IjobVacancy.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(jobVacancyDTO);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobVacancyDTO jobVacancy = await _IjobVacancy.getById(id);
            if (jobVacancy == null)
            {
                return NotFound();
            }

            return View(jobVacancy);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _IjobVacancy.Delete(id);
            await _IjobVacancy.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
