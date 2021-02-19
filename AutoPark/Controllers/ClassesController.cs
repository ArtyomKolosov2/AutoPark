using AutoPark.Controllers.Base;
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
    /// <summary>
    /// Level 1 controller
    /// </summary>
    public class ClassesController : IController
    {
        private readonly List<VehicleType> _types;
        private readonly IOutputService _outputService;
        /// <summary>
        /// Setting up a controller with default types and output service
        /// </summary>
        /// <param name="types"></param>
        /// <param name="outputService"></param>
        public ClassesController(List<VehicleType> types, IOutputService outputService)
        {
            _types = types;
            _outputService = outputService;
        }
        /// <summary>
        /// Run controller
        /// </summary>
        public void RunController()
        {
            foreach (var carType in _types)
            {
                carType.Display();
            }

            _types.Last().TaxCoeff = 1.3m;
            var maxCoef = _types.Max(type => type.TaxCoeff);
            var averageCoeff = _types.Average(type => type.TaxCoeff);
            _outputService.ShowStringWithLineBreak($"{maxCoef:0.00}");
            _outputService.ShowStringWithLineBreak($"{averageCoeff:0.00}");

            foreach (var carType in _types)
            {
                _outputService.ShowStringWithLineBreak(carType.ToString());
            }
        }
    }
}
