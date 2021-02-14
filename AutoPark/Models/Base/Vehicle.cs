using AutoPark.Models.Vehicles;
using System;
using System.Drawing;

namespace AutoPark.Models.Base
{
    public class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {
        private const double TaxWeightMultiplier = 0.0013;
        public Vehicle()
        {

        }

        public Vehicle(
            VehicleType vehicleType, 
            Engine engine,
            string modelName, 
            string registrationNumber,
            int weight,
            int manufactureYear,
            int mileage,
            Color carColor,
            int fuelTankSize)
        {
            VehicleType = vehicleType;
            Engine = engine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = carColor;
            FuelTankSize = fuelTankSize;
        } 

        public Engine Engine { get; set; }
        public VehicleType VehicleType { get; init; }
        public int ManufactureYear { get; init; }
        public string ModelName { get; init; }
        public int FuelTankSize { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        
        public double TaxPerMonth => (Weight * TaxWeightMultiplier) + (VehicleType.TaxCoeff * Engine.TaxCoeff * 30) + 5;
        public override string ToString() => $"{ModelName},{RegistrationNumber},{Weight},{Mileage},{Color},{TaxPerMonth:0.00}";

        public int CompareTo(Vehicle other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other), "Other class can't be null!");
            }

            return TaxPerMonth.CompareTo(other.TaxPerMonth);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(VehicleType.TypeName, ModelName);
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Vehicle other)
            {
                result = Equals(other);
            }
            return result;
        }
        public bool Equals(Vehicle other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other.VehicleType.TypeName == VehicleType.TypeName && other.ModelName == ModelName;
        }
    }
}
