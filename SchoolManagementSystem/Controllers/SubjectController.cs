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
    public class SubjectController : Controller
    {
        private readonly ISubjectComponent _subjectComponent;

        public SubjectController(ISubjectComponent subjectComponent)
        {
            _subjectComponent = subjectComponent;
        }
        // GET: SubjectController
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<SubjectModel> list = _subjectComponent.Subjects();
            return View(list);
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectModel sm )
        {
            try
            {
                _subjectComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = _subjectComponent.GetSubject(id);
            return View(edit);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectModel sm)
        {
            try
            {
                _subjectComponent.Save(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            var del = _subjectComponent.GetSubject(id);
            return View(del);
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _subjectComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
