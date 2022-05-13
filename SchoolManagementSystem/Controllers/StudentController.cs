using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.IComponent;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentComponent _studentComponent;
        private readonly IClassesComponent _classesComponent;
        private readonly ISectionComponent _sectionComponent;

        public StudentController(IStudentComponent studentComponent, IClassesComponent classesComponent, ISectionComponent sectionComponent)
        {
            _studentComponent = studentComponent;
            _classesComponent = classesComponent;
            _sectionComponent = sectionComponent;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            List<StudentModel> list = _studentComponent.Students();
            return View(list);
        }
        public ActionResult LoadSection(int id)
        {
            var data = _sectionComponent.GetSectionByClassId(id);
            return Json(data);
        }
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            var cls = _classesComponent.Classes();
            ViewBag.message = cls;
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel sm)
        {
            try
            {
                _studentComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var cls = _classesComponent.Classes();
            ViewBag.message = cls;
            var get= _studentComponent.GetStudent(id);
            return View(get);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel sm)
        {
            try
            {
                _studentComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
           var get= _studentComponent.GetStudent(id);
            return View(get);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _studentComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
