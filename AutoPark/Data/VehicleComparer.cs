using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data
{
    public class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y) => x.ModelName.CompareTo(y.ModelName);
    }
}
