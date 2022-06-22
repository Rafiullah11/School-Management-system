using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.IComponent;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionComponent _sectionComponent;
        private readonly IClassesComponent _classesComponent;
        public SectionController(ISectionComponent sectionComponent, IClassesComponent classesComponent )
        {
            _sectionComponent = sectionComponent;
            _classesComponent = classesComponent;
        }
        // GET: SectionController
        [AllowAnonymous]
        public ActionResult Index()
        {
            
            List<SectionModel> list = _sectionComponent.Index();
            return View(list);
        }

        // GET: SectionController/Details/5
        public ActionResult Details(int id)
        {
            var get = _sectionComponent.GetSection(id);
            return View(get);
        }

        // GET: SectionController/Create
        public ActionResult Create()
        {
            var data = _classesComponent.Classes();
            ViewBag.message = data;
            return View();
        }

        // POST: SectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionModel sm )
        {
            try
            {
                _sectionComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectionController/Edit/5
        public ActionResult Edit(int id)
        {
           var Edit = _sectionComponent.GetSection(id);
            var data = _classesComponent.Classes();
            ViewBag.message = data;
            return View(Edit);
            
        }

        // POST: SectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionModel sm)
        {
            try
            {
                _sectionComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectionController/Delete/5
        public ActionResult Delete(int id)
        {
           var get= _sectionComponent.GetSection(id);
            return View(get);
        }

        // POST: SectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _sectionComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
