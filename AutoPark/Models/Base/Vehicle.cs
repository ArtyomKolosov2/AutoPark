using AutoPark.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace AutoPark.Models.Base
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const double TaxWeightMultiplier = 0.0013;
        public Vehicle()
        {

        }

        public Vehicle(
            VehicleType vehicleType, 
            string modelName, 
            string registrationNumber,
            int weight,
            int manufactureYear,
            int mileage,
            Color carColor,
            int fuelTankSize)
        {
            VehicleType = vehicleType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = carColor;
            FuelTankSize = fuelTankSize;
        } 
        public VehicleType VehicleType { get; init; }
        public int ManufactureYear { get; init; }
        public string ModelName { get; init; }
        public int FuelTankSize { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        
        public double TaxPerMonth => (Weight * TaxWeightMultiplier) + (VehicleType.TaxCoef * 30) + 5;
        public override string ToString() => $"{ModelName},{RegistrationNumber},{Weight},{Mileage},{Color},{TaxPerMonth.ToString("0.00")}";

        public int CompareTo(Vehicle other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other), "Other class can't be null!");
            }

            return TaxPerMonth.CompareTo(other.TaxPerMonth);

        }
    }
}
