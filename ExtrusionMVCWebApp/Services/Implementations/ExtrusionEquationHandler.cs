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
        public Calculation CalculateByMissing(double weight, double width, double length, double gauge, double coreThickness, double layers)
        {
            var calculation = new Calculation() { Gauge = gauge, Weight = weight, Width = width, Length = length, Layers=layers };
            calculation = this.CalculateByMissing(calculation);
            return (calculation);
        }

        public Calculation CalculateFootageForGivenDiameter(double diameter, Calculation calculation)
        {
            throw new NotImplementedException();
        }

        public Calculation CalculateRollDiameter(Calculation calculation)
        {
            var gauge = calculation.Gauge;
            var rollLenthInInches = calculation.Length*12;
            var coreDiameter = calculation.CoreDiameter + (calculation.CoreThickness*calculation.Layers);
            double rollDiameter = coreDiameter;
            double inchesLastTurn;
            for(double x=rollLenthInInches; x>=0; x-=inchesLastTurn)
            {
                rollDiameter += (gauge * calculation.Layers * 2);
                inchesLastTurn = Math.PI * rollDiameter;
               
            }
           
            calculation.Diameter = rollDiameter;
            return calculation;
        }

        public Calculation CalculateRollFootageFromBags(Calculation calculation)
        {
            calculation.Length = this.CalculateRollFootageFromBags(calculation.Length, calculation.NumberOnRoll);
            return calculation;
        }

        public double CalculateRollFootageFromBags(double length, double numberOfBags)
        {
            var rollLength = length * numberOfBags / 12;
            return rollLength;
        }
    }
}
