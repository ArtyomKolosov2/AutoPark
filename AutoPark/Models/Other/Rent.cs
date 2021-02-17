using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Other
{
    public class Rent
    {
        public int VehicleId { get; set; }
        public DateTime RentDate { get; set; }
        public double Cost { get; set; }
        public Rent()
        {
            RentDate = DateTime.Now;
        }
        public Rent(int vehicleId, DateTime time, double cost)
        {
            VehicleId = vehicleId;
            RentDate = time;
            Cost = cost;
        }
    }
}
