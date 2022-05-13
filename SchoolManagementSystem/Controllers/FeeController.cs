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
    public class FeeController : Controller
    {
        private readonly IFeeComponent _feeComponent;
        private readonly IStudentComponent _studentComponent;
        private readonly ISectionComponent _sectionComponent;
        private readonly IClassesComponent _classesComponent;

        public FeeController(IFeeComponent feeComponent, IStudentComponent studentComponent,
            ISectionComponent sectionComponent,IClassesComponent classesComponent)
        {
            _feeComponent = feeComponent;
            _studentComponent = studentComponent;
            _sectionComponent = sectionComponent;
            _classesComponent = classesComponent;
        }
        // GET: FeeController
        public ActionResult Index()
        {
            List<FeeViewModel> list = _feeComponent.Index();
            return View(list);
        }

        public ActionResult LoadSection(int id)
        {
            var data = _sectionComponent.GetSectionByClassId(id);
            return Json(data);
        }
        // GET: FeeController/Details/5
        public ActionResult LoadStudents(int classId,int sectionId)
        {
             var data = _studentComponent.GetStudentBySectionId(classId,sectionId);
            return Json(data);
        } 
        
        // GET: FeeController/Create
        public ActionResult Create()
        {
            var cls = _classesComponent.Classes();
            ViewBag.message = cls;
            return View();
        }

        // POST: FeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeeViewModel fvm)
        {
            try
            {
                _feeComponent.Save(fvm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var cls = _classesComponent.Classes();
            ViewBag.message = cls;
            var get = _feeComponent.GetFee(id);
            return View(get);
        }

        // POST: FeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeeViewModel fvm)
        {
            try
            {
                _feeComponent.Save(fvm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeeController/Delete/5
        public ActionResult Delete(int id)
        {
           var get= _feeComponent.GetFee(id);
            return View(get);
        }

        // POST: FeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FeeViewModel fvm, int id)
        {
            try
            {
                _feeComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
