using AutoPark.Models.Base;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService
{
    public class ConsoleOutputService : IOutputService
    {
        public void ShowVehiclesList<T>(IEnumerable<T> vehicles) where T : Vehicle
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
