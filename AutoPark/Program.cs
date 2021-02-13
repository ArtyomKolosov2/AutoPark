using AutoPark.Models;
using AutoPark.Models.Base;
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
        
        static void Main(string[] args)
        {
            IOutputService outputService = new ConsoleOutputService();
            var carTypeList = new List<VehicleType>()
            {
                new VehicleType("Bus", 1.2),
                new VehicleType("Car", 1),
                new VehicleType("Rink", 1.5),
                new VehicleType("Tractor", 1.2),
            };
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

            var carList = new List<Vehicle>()
            {
                new(carTypeList[0], "Volkswagen Crafter", "5427 AX-7", 2020, 2015, 376000, Color.Blue, 50),
                new(carTypeList[0], "Volkswagen Crafter", "6427 AA-7", 2500, 2013, 227010, Color.White, 50),
                new(carTypeList[0], "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 50),
                new(carTypeList[1], "Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 50),
                new(carTypeList[1], "Tesla model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White, 50),
                new(carTypeList[2], "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 50),
                new(carTypeList[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 50),
            };
            outputService.ShowVehiclesList(carList);
            carList.Sort();
            outputService.ShowVehiclesList(carList);
            Console.WriteLine(
                $"Max milleage = {carList.Max(car => car.Mileage)}\n" +
                $"Min milleage = {carList.Min(car => car.Mileage)}");

        }
    }
}
