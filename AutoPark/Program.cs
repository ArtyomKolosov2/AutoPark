using AutoPark.Models;
using AutoPark.Models.Base;
using AutoPark.Models.Engines;
using AutoPark.Models.Vehicles;
using AutoPark.Views.OutputService;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AutoPark
{
    class Program
    {
        private static List<VehicleType> _vehiclesTypesDefaultList => new List<VehicleType>()
        {
            new VehicleType("Bus", 1.2),
            new VehicleType("Car", 1),
            new VehicleType("Rink", 1.5),
            new VehicleType("Tractor", 1.2),
        };

        private static List<Vehicle> _vehiclesDefaultList => new List<Vehicle>()
        {
            new(_vehiclesTypesDefaultList[0], new GasolineEngine(2, 8.1, 75), "Volkswagen Crafter", "5427 AX-7", 2020, 2015, 376000, Color.Blue, 50),
            new(_vehiclesTypesDefaultList[0], new GasolineEngine(2.18, 8.5, 75), "Volkswagen Crafter", "6427 AA-7", 2500, 2013, 227010, Color.White, 50),
            new(_vehiclesTypesDefaultList[0], new ElectricalEngine(50, 150),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 50),
            new(_vehiclesTypesDefaultList[1], new DieselEngine(1.6, 7.2, 55), "Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 50),
            new(_vehiclesTypesDefaultList[1], new ElectricalEngine(25, 70), "Tesla model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White, 50),
            new(_vehiclesTypesDefaultList[2], new DieselEngine(3.2, 25, 20), "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 50),
            new(_vehiclesTypesDefaultList[3], new DieselEngine(4.75, 20.1, 135), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 50),
         };
        static void Main(string[] args)
        {
            IOutputService<Vehicle> outputService = new ConsoleOutputService();
            var carTypeList = _vehiclesTypesDefaultList;
            foreach (var carType in carTypeList)
            {
                carType.Display();
            }
            carTypeList.Last().TaxCoeff = 1.3;
            var maxCoef = carTypeList.Max(car => car.TaxCoeff);
            Console.WriteLine(maxCoef);
            foreach (var carType in carTypeList)
            {
                Console.WriteLine(carType);
            }

            var carList = _vehiclesDefaultList;
            outputService.ShowElementsList(carList);
            carList.Sort();
            outputService.ShowElementsList(carList);
            Console.WriteLine(
                $"Max milleage = {carList.Max(car => car.Mileage)}\n" +
                $"Min milleage = {carList.Min(car => car.Mileage)}");
   

            outputService.ShowSameElements(carList);
        }
    }
}
