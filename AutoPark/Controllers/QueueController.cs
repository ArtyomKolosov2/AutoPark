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
    /// <summary>
    /// Level 6
    /// </summary>
    public class QueueController : IController
    {
        private readonly CollectionContext _context;
        private readonly IOutputService _outputService;
        /// <summary>
        /// Setting up a controller
        /// </summary>
        /// <param name="context"></param>
        /// <param name="outputService"></param>
        public QueueController(CollectionContext context, IOutputService outputService)
        {
            _context = context;
            _outputService = outputService;
        }
        /// <summary>
        /// Run controller
        /// </summary>
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
