using ExtrusionMVCWebApp.Models;
using ExtrusionMVCWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Services.Implementations
{
    public class ExtrusionEquationHandler : IExtrusionEquationHandler
    {
        public Calculation CalculateByMissing(Calculation calculation)
        {
            var gauge = calculation.Gauge;
            var weight = calculation.Weight;
            var width = calculation.Width;
            var length = calculation.Length;
            if (gauge == 0)
            {
                calculation.Gauge = weight * 2.5 / width / length;
            }
            else if (weight == 0)
            {
                calculation.Weight = (gauge * width * length) / 2.5;
            }
            else if (width == 0)
            {
                calculation.Width = (weight * 2.5) / (gauge * length);

            }
            else
            {
                calculation.Length = (weight * 2.5) / (gauge * width);
            }
            return calculation;
        }
        public Calculation CalculateByMissing(double weight, double width, double length, double gauge)
        {
            var calculation = new Calculation() { Gauge = gauge, Weight = weight, Width = width, Length = length };
            calculation = this.CalculateByMissing(calculation);
            //if (gauge == 0)
            //{
            //    gauge = weight * 2.5 / width / length;
            //}
            //else if (weight == 0)
            //{
            //    weight = (gauge * width * length) / 2.5;
            //}
            //else if (width == 0)
            //{
            //    width = (weight * 2.5) / (gauge * length);

            //}
            //else
            //{
            //    length = (weight * 2.5) / (gauge * width);
            //}
            return (calculation);
        }

        public Calculation CalculateRollDiameter(Calculation calculation)
        {
            var gauge = calculation.Gauge;
            var rollLenthInInches = calculation.Length*12;
            var coreDiameter = calculation.CoreDiameter + 1.0;
            double rollDiameter = coreDiameter;
            double inchesLastTurn;
            for(double x=rollLenthInInches; x>=0; x-=inchesLastTurn)
            {
                rollDiameter += (gauge * 4);
                inchesLastTurn = Math.PI * rollDiameter;
                //rollLenthInInches -= inchesLastTurn;
            }
            //TODO implement roll diameter logic
            calculation.Diameter = rollDiameter;
            return calculation;
        }
    }
}
