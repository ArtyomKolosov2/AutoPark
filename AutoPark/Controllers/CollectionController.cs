using AutoPark.Controllers.Base;
using AutoPark.Data;
using AutoPark.Data.UserCollection;
using AutoPark.Models.Base;
using AutoPark.Models.Engines;
using AutoPark.Models.Other;
using AutoPark.Models.Vehicles;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers
{
    public class CollectionController : IController
    {
        private readonly CollectionContext _collectionContext;
        private readonly IOutputService _outputService;
        public CollectionController(CollectionContext collectionContext, IOutputService outputService)
        {
            _collectionContext = collectionContext;
            _outputService = outputService;
        }

        public void RunController()
        {
            var rents = _collectionContext.LoadRents();
            var vehicleTypes = _collectionContext.LoadTypes();
            var vehicles = _collectionContext.LoadVehicles(rents, vehicleTypes);
            var collections = new Collections(vehicleTypes, vehicles, _outputService);
            collections.Print();
            collections.Vehicles.Add
             (
                new(7, collections.VehicleTypes[3] , new DieselEngine(4.75, 20.1, 135), "МТЗ 40", "2268 AB-2", 1200, 2020, 109, Colors.Blue)
                {
                    Rents = new List<Rent> 
                    { 
                        new Rent(7, DateTime.Now, 13.5m)
                    },
                }
             );
            collections.Delete(1);
            collections.Delete(4);
            collections.Print();
            collections.Sort();
            collections.Print();
        }
    }
}
