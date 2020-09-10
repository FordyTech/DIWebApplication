using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Injection2([FromServices] ILog log)
        {
            log.Info("Controller executing using Action Method Injection");
            return View();
        }
    }
}
