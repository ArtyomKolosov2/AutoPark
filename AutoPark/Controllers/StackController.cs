using AutoPark.Controllers.Base;
using AutoPark.Data;
using AutoPark.Data.UserCollections;
using AutoPark.Models.Base;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers
{
    public class StackController : IController
    {
        private readonly CollectionContext _context;
        private readonly IOutputService _outputService;
        public StackController(CollectionContext context, IOutputService outputService)
        {
            _context = context;
            _outputService = outputService;
        }

        public void RunController()
        {
            var stack = new UserStack<Vehicle>(16);
            _outputService.ShowVehicleEnumerable(stack);
            var counter = 1;

            foreach (var vehicle in _context.UserCollection.Vehicles)
            {
                _outputService.ShowStringWithLineBreak($"{counter++}. {vehicle.ModelName} заехало в гараж");
                stack.Push(vehicle);
            }
            counter--;
            while (stack.Count != 0)
            {
                _outputService.ShowStringWithLineBreak($"{counter--}. {stack.Pop().ModelName} выехало из гаража");
            }
        }
    }
}
