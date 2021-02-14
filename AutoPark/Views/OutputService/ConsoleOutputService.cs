using AutoPark.Models.Base;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService
{
    public class ConsoleOutputService : IOutputService<Vehicle>
    {
        public void ShowSameElements(IEnumerable<Vehicle> vehicles)
        {
            var duplicates = 
                vehicles.GroupBy(car => car)
                .Where(group => group.Count() > 1)
                .SelectMany(group => group);
            ShowElementsList(duplicates);
        }

        public void ShowElementsList(IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
