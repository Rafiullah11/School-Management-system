using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext context;

        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public ViewResult Index()
        {
            DashBoardViewModel dashboard = new DashBoardViewModel();

            dashboard.Teacher_count = context.Teachers.Count();
            dashboard.Student_count = context.Students.Count();
            dashboard.Employee_count = context.Employees.Count();

            int hour = DateTime.Now.Hour;
            ViewBag.viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View(dashboard);
        
            //return View(dashboard, viewModel);

        }  
        public ViewResult MyView()
        {
            //int hour = DateTime.Now.Hour;
            //string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
            //return View("MyView", viewModel);
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
