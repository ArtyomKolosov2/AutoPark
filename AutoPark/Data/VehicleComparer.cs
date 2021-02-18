using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data
{
    /// <summary>
    /// Vehicle comparer
    /// </summary>
    public class VehicleComparer : IComparer<Vehicle>
    {
        /// <summary>
        /// Compares cars by their model names
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int Compare(Vehicle x, Vehicle y) => x.ModelName.CompareTo(y.ModelName);
    }
}
