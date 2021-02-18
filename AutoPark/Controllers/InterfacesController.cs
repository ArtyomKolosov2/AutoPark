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
    public class InterfacesController : IController
    {
        private readonly List<VehicleType> _types;
        private readonly List<Vehicle> _vehicles;
        private readonly IOutputService _outputService;
        public InterfacesController(List<VehicleType> types, List<Vehicle> vehicles, IOutputService outputService)
        {
            _vehicles = vehicles;
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
            var maxCoef = _types.Max(car => car.TaxCoeff);
            _outputService.ShowStringWithLineBreak($"{maxCoef:0.00}");
            foreach (var carType in _types)
            {
                _outputService.ShowStringWithLineBreak(carType.ToString());
            }

            var carList = _vehicles;
            _outputService.ShowVehicleEnumerable(carList);
            carList.Sort();
            _outputService.ShowVehicleEnumerable(carList);
            _outputService.ShowStringWithLineBreak(
                $"Max milleage = {carList.Max(car => car.Mileage)}\n" +
                $"Min milleage = {carList.Min(car => car.Mileage)}");
        }
    }
}
