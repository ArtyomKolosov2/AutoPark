using AutoPark.Models.Base;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService
{
    /// <summary>
    /// Implementation of output service
    /// </summary>
    public class ConsoleOutputService : IOutputService
    {
        public void ShowSameVehicles(IEnumerable<Vehicle> elements)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            var duplicates = 
                elements.GroupBy(car => car)
                .Where(group => group.Count() > 1)
                .SelectMany(group => group);

            ShowVehicleEnumerable(duplicates);
        }

        public void ShowVehicleEnumerable(IEnumerable<Vehicle> elements)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            foreach (var vehicle in elements)
            {
                Console.WriteLine(vehicle);
            }
        }

        public void ShowStringWithLineBreak(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowStringWithoutLineBreak(string message)
        {
            Console.Write(message);
        }
    }
}
