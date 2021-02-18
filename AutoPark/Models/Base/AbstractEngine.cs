using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Base
{
    /// <summary>
    /// Base class for engines
    /// </summary>
    public abstract class AbstractEngine
    {
        public string Type { get; set; }
        public decimal TaxCoeff { get; set; }
        public int EngineCapacity { get; protected set; }
        protected AbstractEngine(string type, decimal coef)
        {
            Type = type;
            TaxCoeff = coef;
        }
        public abstract double GetMaxKilometers(double fuelTankCapacity);
    }
}
