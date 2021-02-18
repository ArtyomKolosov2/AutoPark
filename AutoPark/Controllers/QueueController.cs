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
    public class QueueController : IController
    {
        private readonly CollectionContext _context;
        private readonly IOutputService _outputService;
        public QueueController(CollectionContext context, IOutputService outputService)
        {
            _context = context;
            _outputService = outputService;
        }

        public void RunController()
        {
            var queue = new UserQueue<Vehicle>(_context.UserCollection.Vehicles);
            _outputService.ShowVehicleEnumerable(queue);
            var counter = 1;
            foreach (var vehicle in queue)
            {
                _outputService.ShowStringWithLineBreak($"Auto {counter++} washed!: {vehicle.ModelName}");
            }
        }
    }
}
