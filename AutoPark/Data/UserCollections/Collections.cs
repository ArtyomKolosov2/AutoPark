using AutoPark.Models.Base;
using AutoPark.Models.Engines;
using AutoPark.Models.Other;
using AutoPark.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data.UserCollection
{
    public class Collections
    {
        public List<VehicleType> VehicleTypes { get; set; } = new();
        public List<Vehicle> Vehicles { get; set; } = new();
        public Collections()
        {

        }
        public Collections(List<VehicleType> vehicleTypes, List<Vehicle> vehicles)
        {
            VehicleTypes = vehicleTypes;
            Vehicles = vehicles;
        }
        
        private bool IsVehicleIndexValid(int index) => index >= 0 && index < Vehicles.Count;
        
        public void Insert(int index, Vehicle vehicle)
        {
            Vehicles.Insert(index, vehicle);
        }
        public int Delete(int index)
        {
            var returnIndex = -1;
            if (IsVehicleIndexValid(index))
            {
                Vehicles.RemoveAt(index);
                returnIndex = index;
            }
            return returnIndex;
        }
        public double SumTotalProfit() => Vehicles.Sum(vehicle => vehicle.TotalProfit);
        public void Print()
        {
            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine(
                    $"{vehicle.Id,-5}" +
                    $"{vehicle.VehicleType.TypeName,-10}" +
                    $"{vehicle.ModelName,-25}" +
                    $"{vehicle.RegistrationNumber,-15}" +
                    $"{vehicle.Weight,-15}" +
                    $"{vehicle.ManufactureYear,-10}" +
                    $"{vehicle.Mileage,-10}" +
                    $"{vehicle.Color,-10}" +
                    $"{vehicle.TotalIncome,-10:0.00}" +
                    $"{vehicle.TaxPerMonth,-10:0.00}" +
                    $"{vehicle.TotalProfit,-10:0.00}");
            }
        }
        public void Sort(IComparer<Vehicle> comparer)
        {
            Vehicles.Sort(comparer);
        }

        public void Sort()
        {
            Vehicles.Sort(new VehicleComparer());
        }

    }
}
