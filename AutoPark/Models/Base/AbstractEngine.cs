using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Base
{
    public abstract class AbstractEngine
    {
        public string Type { get; set; }
        public double TaxCoeff { get; set; }
        public int EngineCapacity { get; protected set; }
        protected AbstractEngine(string type, double coef)
        {
            Type = type;
            TaxCoeff = coef;
        }
        public abstract double GetMaxKilometers(double fuelTank);
    }
}
