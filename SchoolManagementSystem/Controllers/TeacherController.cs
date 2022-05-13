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
    public class TeacherController : Controller
    {
        private readonly ITeacherComponent _teacherComponent;
        private readonly ISubjectComponent _subjectComponent;

        public TeacherController(ITeacherComponent teacherComponent, ISubjectComponent subjectComponent)
        {
            _teacherComponent = teacherComponent;
            _subjectComponent = subjectComponent;
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            List<TeacherViewModel> list = _teacherComponent.Teacher();
            return View(list);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            var SubDD = _subjectComponent.Subjects();
            ViewBag.SubjectDD = SubDD;
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel tvm)
        {
            try
            {
                _teacherComponent.Save(tvm);
                TempData["Success"] = "New Record has been add successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var SubDD = _subjectComponent.Subjects();
            ViewBag.SubjectDD = SubDD;
            var get = _teacherComponent.GetTeacher(id);
            return View(get);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherViewModel tvm)
        {
            try
            {
                _teacherComponent.Save(tvm);
                TempData["Success"] = "Record  has been updated successfuly..";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
           var del = _teacherComponent.GetTeacher(id);
            return View(del);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _teacherComponent.Delete(id);
                TempData["Error"] = "Record  has been deleted successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
