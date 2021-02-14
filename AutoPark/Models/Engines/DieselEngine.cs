using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public class DieselEngine : CombustionEngine
    {
        public DieselEngine(
            double engineVolume,
            double fuelConsumptionPerHundred,
            int engineCapacity)
            : base(EngineTypeConstants.DIESEL, 1.2)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPerHundred = fuelConsumptionPerHundred;
            EngineCapacity = engineCapacity;
        }
    }
}
