using AutoPark.Controllers;
using AutoPark.Controllers.Base;
using AutoPark.Data;
using AutoPark.Data.Extensions;
using AutoPark.Data.UserCollection;
using AutoPark.Models;
using AutoPark.Models.Base;
using AutoPark.Models.Engines;
using AutoPark.Models.Vehicles;
using AutoPark.Views.OutputService;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace AutoPark
{
    static class Program
    {
        private static void SetUpLocale()
        {
            var customCulture = new CultureInfo("en-US");
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;
        }
        private static List<VehicleType> VehiclesTypesDefaultList => new List<VehicleType>()
        {
            new VehicleType(1, "Bus", 1.2m),
            new VehicleType(2, "Car", 1m),
            new VehicleType(3, "Rink", 1.5m),
            new VehicleType(4, "Tractor", 1.2m),
        };

        private static List<Vehicle> VehiclesDefaultList => new List<Vehicle>()
        {
            new(1, VehiclesTypesDefaultList[0], new GasolineEngine(2, 8.1, 75), "Volkswagen Crafter", "5427 AX-7", 2020, 2015, 376000, Colors.Blue),
            new(2, VehiclesTypesDefaultList[0], new GasolineEngine(2.18, 8.5, 75), "Volkswagen Crafter", "6427 AA-7", 2500, 2013, 227010, Colors.White),
            new(3, VehiclesTypesDefaultList[0], new ElectricalEngine(50, 150),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Colors.Green),
            new(4, VehiclesTypesDefaultList[1], new DieselEngine(1.6, 7.2, 55), "Golf 5", "8682 AX-7", 1200, 2006, 230451, Colors.Gray),
            new(5, VehiclesTypesDefaultList[1], new ElectricalEngine(25, 70), "Tesla model S 70D", "E001 AA-7", 2200, 2019, 10454, Colors.White),
            new(6, VehiclesTypesDefaultList[2], new DieselEngine(3.2, 25, 20), "Hamm HD 12 VV", null, 3000, 2016, 122, Colors.Yellow),
            new(7, VehiclesTypesDefaultList[3], new DieselEngine(4.75, 20.1, 135), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Colors.Red),
         };
        static void Main(string[] args)
        {
            SetUpLocale();
            IOutputService outputService = new ConsoleOutputService();
            var context = new CollectionContext();
            var listOfControllers = new List<IController>()
            {
                new ClassesController(VehiclesTypesDefaultList, outputService),
                new InterfacesController(VehiclesTypesDefaultList, VehiclesDefaultList, outputService),
                new InheritanceController(VehiclesDefaultList, outputService),
                new AbstractionController(VehiclesDefaultList, outputService),
                new CollectionController(context, outputService),
                new QueueController(context, outputService),
                new StackController(context, outputService),
                new DictionaryController(@"Data\Files\orders.csv", outputService)
            };
            for (var index = 0; index < listOfControllers.Count; index++)
            {
                outputService.ShowStringWithLineBreak($"Level: {index + 1}".Center(40, '='));

                var controller = listOfControllers[index];
                controller.RunController();
            }
        }
    }
}
