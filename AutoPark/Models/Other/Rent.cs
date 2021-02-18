using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Other
{
    /// <summary>
    /// Rent object
    /// </summary>
    public class Rent
    {
        public int VehicleId { get; set; }
        public DateTime RentDate { get; set; }
        public decimal Cost { get; set; }
        public Rent()
        {
            RentDate = DateTime.Now;
        }
        public Rent(int vehicleId, DateTime time, decimal cost)
        {
            VehicleId = vehicleId;
            RentDate = time;
            Cost = cost;
        }
    }
}
