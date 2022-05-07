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
        public IActionResult GetAnswer(double weight, double width, double length, double gauge,double NumberOnRoll, double coreDiameter, double coreThickness, double layers)
        {
            if(NumberOnRoll!=0)
            {
                length = _extrusionEquationHandler.CalculateRollFootageFromBags(length, NumberOnRoll);
            }
            var calculationModel =_extrusionEquationHandler.CalculateByMissing(weight, width, length, gauge, coreThickness, layers);
            calculationModel.NumberOnRoll = NumberOnRoll;
            calculationModel.CoreDiameter = coreDiameter;
            calculationModel.CoreThickness = coreThickness;
            calculationModel = _extrusionEquationHandler.CalculateRollDiameter(calculationModel);
            calculationModel.CoreThickness = coreThickness;
            
            return View(calculationModel);
        }
    }
}
