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
    [Authorize]
    public class ClassesController : Controller
    {
        private IClassesComponent _classesComponent;
        public ClassesController(IClassesComponent classesComponent)
        {
            _classesComponent = classesComponent;
        }
        // GET: ClassesController
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<ClassesModel> list = _classesComponent.Classes();
            return View(list);
        }

        // GET: ClassesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassesController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ClassesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassesModel cm)
        {
            try
            {
                _classesComponent.Save(cm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassesController/Edit/5
        public ActionResult Edit(int id)
        {
            var Edit = _classesComponent.GetClasses(id);
            return View(Edit);
        }

        // POST: ClassesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassesModel cm )
        {
            try
            {
                var updte = _classesComponent.Save(cm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassesController/Delete/5
        public ActionResult Delete(int id)
        {
          var get= _classesComponent.GetClasses(id);
            return View(get);
        }

        // POST: ClassesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _classesComponent.DeleteClasses(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
