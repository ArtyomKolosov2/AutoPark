using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(
            double engineVolume, 
            double fuelConsumptionPerHundred,
            int engineCapacity) 
            : base(EngineTypeConstants.GASOLINE, 1m)
        {
            EngineVolume = engineVolume;
            EngineCapacity = engineCapacity;
            FuelConsumptionPerHundred = fuelConsumptionPerHundred;
        }
    }
}
