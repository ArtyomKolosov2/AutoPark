using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; set; }
        public ElectricalEngine(double electricityConsumption, int engineCapacity) :
            base(EngineTypeConstants.ELECTRICAL, 0.1m)
        {
            ElectricityConsumption = electricityConsumption;
            EngineCapacity = engineCapacity;
        }
        public override double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;
        
    }
}
