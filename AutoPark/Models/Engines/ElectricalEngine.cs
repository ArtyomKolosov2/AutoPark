using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public class ElectricalEngine : Engine
    {
        public double ElectricityConsumption { get; set; }
        public ElectricalEngine(double electricityConsumption, int engineCapacity) :
            base(EngineTypeConstants.ELECTRICAL, 0.1)
        {
            ElectricityConsumption = electricityConsumption;
            EngineCapacity = engineCapacity;
        }
        public double GetMaxKilometeres(double batterySize) => batterySize / ElectricityConsumption;
        
    }
}
