﻿using ExtrusionMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Services.Interfaces
{
    public interface IExtrusionEquationHandler
    {
        public Calculation CalculateByMissing(double weight, double width, double length, double gauge, double coreThickness, double layers);
        public Calculation CalculateByMissing(Calculation calculation);
        public Calculation CalculateRollDiameter(Calculation calculation);
        public Calculation CalculateRollFootageFromBags(Calculation calculation);
        public double CalculateRollFootageFromBags(double length, double numberOfBags);
        public Calculation CalculateFootageForGivenDiameter(double diameter, Calculation calculation);
    }
}
