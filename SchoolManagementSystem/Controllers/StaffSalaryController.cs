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
    public class StaffSalaryController : Controller
    {
        private readonly IStaffSalaryComponent _staffSalaryComponent;
        private readonly ITeacherComponent _teacherComponent;
        private readonly IEmployeeComponent _employeeComponent;

        public StaffSalaryController(IStaffSalaryComponent staffSalaryComponent,ITeacherComponent teacherComponent,IEmployeeComponent employeeComponent)
        {
            _staffSalaryComponent = staffSalaryComponent;
            _teacherComponent = teacherComponent;
            _employeeComponent = employeeComponent;
        }
        // GET: StaffSalaryController
        public ActionResult Index()
        {
            List<StaffSalaryViewModel> list = _staffSalaryComponent.StaffSalary();
            return View(list);
        }

        // GET: StaffSalaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffSalaryController/Create
        public ActionResult Create()
        {
            var Teach = _teacherComponent.Teacher();
            var listTeacher =new List<TeacherViewModel>();
            foreach (var item in Teach)
            {
                listTeacher.Add(new TeacherViewModel()
                {
                    TeacherId=item.Id,
                    Name=item.Name
                });
            }
            ViewBag.Message = listTeacher;
            var Emp = _employeeComponent.Employee();
            var employees = new List<EmployeeViewModel>();
            foreach (var item in Emp)
            {
                employees.Add(new EmployeeViewModel()
                {
                    EmployeeId = item.Id,
                    Name = item.Name
                });
            }
            ViewBag.Employee = employees;
            return View();
        }

        // POST: StaffSalaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffSalaryViewModel svm)
        {
            try
            {
                TempData["Success"] = "Data Added Successfuly";
                _staffSalaryComponent.Save(svm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffSalaryController/Edit/5
        public ActionResult Edit(int id)
        {

            var edit = _staffSalaryComponent.GetStaffSalary(id);
           
            var Teach = _teacherComponent.Teacher();
            var listTeacher = new List<TeacherViewModel>();
            foreach (var item in Teach)
            {
                listTeacher.Add(new TeacherViewModel()
                {
                    TeacherId = item.Id,
                    Name = item.Name
                });
            }
            ViewBag.Message = listTeacher;
            var Emp = _employeeComponent.Employee();
            var employees = new List<EmployeeViewModel>();
            foreach (var item in Emp)
            {
                employees.Add(new EmployeeViewModel()
                {
                    EmployeeId = item.Id,
                    Name = item.Name
                });
            }
            ViewBag.Employee = employees;
            return View(edit);
        }

        // POST: StaffSalaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( StaffSalaryViewModel svm)
        {
            try
            {
                TempData["Success"] = "Data Updated Successfuly";
                _staffSalaryComponent.Save(svm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffSalaryController/Delete/5
        public ActionResult Delete(int id)
        {
            var del = _staffSalaryComponent.GetStaffSalary(id);
            return View(del);
        }

        // POST: StaffSalaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TempData["Error"] = "Data Deleted Successfuly";
                _staffSalaryComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
