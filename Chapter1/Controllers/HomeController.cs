using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chapter1.Services.Interfaces;
using Chapter1.Services.Implementation;
using Chapter1.models;
using Microsoft.AspNet.Identity;

namespace Chapter1.Controllers
{
    public class HomeController : Controller
    {
       private IViewEmployees employees;

        public HomeController(IViewEmployees _employees)
        {
            employees = _employees;

        }

        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            return View();
        }
        
        /// <summary>
        /// Test Method for IOC container
        /// </summary>
        /// <returns></returns>
        public ActionResult viewEmployees()
        {
            IEnumerable<Employee> list = employees.viewemployee();
            return View(list);

        }
    }
}