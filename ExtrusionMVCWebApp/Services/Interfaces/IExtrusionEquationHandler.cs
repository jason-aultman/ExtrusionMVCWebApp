using ExtrusionMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Services.Interfaces
{
    public interface IExtrusionEquationHandler
    {
        public Calculation CalculateByMissing(double weight, double width, double length, double gauge);
        public Calculation CalculateByMissing(Calculation calculation);
        public Calculation CalculateRollDiameter(Calculation calculation);
    }
}
