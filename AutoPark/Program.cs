using AutoPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPark
{
    class Program
    {
        static void Main(string[] args)
        {
            var carList = new List<VehicleType>()
            {
                new VehicleType("Bus", 1.2),
                new VehicleType("Car", 1),
                new VehicleType("Rink", 1.5),
                new VehicleType("Tractor", 1.2),
            };
            foreach (var car in carList)
            {
                car.Display();
            }
            carList.Last().TaxCoef = 1.3;
            var maxCoef = carList.Max(car => car.TaxCoef);
            Console.WriteLine(maxCoef);
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }
        }
    }
}
