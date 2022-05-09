using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtrusionMVCWebApp.Models
{
    public class Calculation
    {
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Gauge { get; set; }
        public double Length { get; set; }
        public double NumberOnRoll { get; set; }
        public double TotalNumberForOrder { get; set; }
        public double Diameter { get; set; }
        public double CoreDiameter { get; set; }
        public double CoreThickness { get; set; }
        public double Layers { get; set; }
        public double MaxDiameter { get; set; }
        public int NumberOfRolls { get; set; }
        public bool EvenRolls { get; set; }
    }
   
  
   
}
