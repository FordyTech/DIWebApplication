using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DIWebApplication.Models;

namespace DIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ILog _log;

        public HomeController(ILog log) // Constructor injection!
        {
            _log = log;
        }

        public IActionResult Index()   
        {
            return View();
        }


        public IActionResult Injection1()
        {
            _log.Info("Contoller executing using constructor injection");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
