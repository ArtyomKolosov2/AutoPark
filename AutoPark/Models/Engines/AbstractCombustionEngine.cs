using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineVolume { get; set; }
        public double FuelConsumptionPerHundred { get; set; }
        public AbstractCombustionEngine(string typeName, double taxCoeff)
            :base(typeName, taxCoeff)
        {

        }
        public override double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100 / FuelConsumptionPerHundred;
    }
}
