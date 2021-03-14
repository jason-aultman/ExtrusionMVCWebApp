using ExtrusionMVCWebApp.Models;
using ExtrusionMVCWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IExtrusionEquationHandler _extrusionEquationHandler;
        public CalculatorController(IExtrusionEquationHandler extrusion)
        {
            _extrusionEquationHandler = extrusion;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAnswer(double weight, double width, double length, double gauge, bool is_Por, double CoreThickness)
        {
            var calculationModel =_extrusionEquationHandler.CalculateByMissing(weight, width, length, gauge);
            calculationModel.Is_Por = is_Por;
            calculationModel.CoreThickness = CoreThickness;
            calculationModel = _extrusionEquationHandler.CalculateRollDiameter(calculationModel);
            return View(calculationModel);
        }
    }
}
