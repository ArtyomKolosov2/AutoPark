﻿using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Engines
{
    public class CombustionEngine : Engine
    {
        public int EngineVolume { get; set; }
        public int FuelConsumptionPerHundred { get; set; }
        public CombustionEngine(string typeName, double taxCoeff)
            :base(typeName, taxCoeff)
        {

        }
        public double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100 / FuelConsumptionPerHundred;
    }
}
