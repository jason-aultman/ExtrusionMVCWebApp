using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Controllers
{
    public class TroubleshootingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
