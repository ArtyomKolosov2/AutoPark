using AutoPark.Controllers.Base;
using AutoPark.Models.Base;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers
{
    public class AbstractionController : IController
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IOutputService _outputService;
        public AbstractionController(List<Vehicle> vehicles, IOutputService outputService)
        {
            _vehicles = vehicles;
            _outputService = outputService;
        }
        public void RunController()
        {
            var maxKilometresCar = _vehicles.Aggregate((a, b) => a.MaxKilometresRange > b.MaxKilometresRange ? a : b);
            _outputService.ShowStringWithLineBreak(
                $"Max kilometres car name: {maxKilometresCar.ModelName} \n" +
                $"Km: {maxKilometresCar.MaxKilometresRange:0.00}");
        }
    }
}
