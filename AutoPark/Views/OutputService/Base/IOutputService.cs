using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService.Base
{
    interface IOutputService
    {
        public void ShowVehiclesList<T>(IEnumerable<T> vehicles) where T : Vehicle;
    }
}
