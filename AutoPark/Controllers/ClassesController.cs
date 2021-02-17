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
    public class ClassesController : IController
    {
        private readonly List<VehicleType> _types;
        private readonly IOutputService _outputService;
        public ClassesController(List<VehicleType> types, IOutputService outputService)
        {
            _types = types;
            _outputService = outputService;
        }
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
