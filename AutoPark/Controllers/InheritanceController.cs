using AutoPark.Controllers.Base;
using AutoPark.Data.Extensions;
using AutoPark.Models.Base;
using AutoPark.Models.Vehicles;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers
{
    public class InheritanceController : IController
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IOutputService _outputService;
        public InheritanceController(List<Vehicle> vehicles, IOutputService outputService)
        {
            _vehicles = vehicles;
            _outputService = outputService;
        }
        public void RunController()
        {
            _outputService.ShowVehicleEnumerable(_vehicles);
            _outputService.ShowStringWithLineBreak("Same cars".Center(30, '-'));
            _outputService.ShowSameVehicles(_vehicles);
        }
    }
}
