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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeComponent _employeeComponent;

        public EmployeeController(IEmployeeComponent employeeComponent)
        {
            _employeeComponent = employeeComponent;
        }
        // GET: EmployeeController
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<EmployeeViewModel> list = _employeeComponent.Employee();

            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            _employeeComponent.GetEmployee(id);
            return View(id);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel evm)
        {
            try
            {
                _employeeComponent.Save(evm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var get = _employeeComponent.GetEmployee(id);
            return View(get);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel evm)
        {
            try
            {
                _employeeComponent.Save(evm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
           var del= _employeeComponent.GetEmployee(id);
            return View(del);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _employeeComponent.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
