using AutoPark.Models.Other;
using AutoPark.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AutoPark.Models.Base
{
    /// <summary>
    /// Class, that represents main specifications of vehicles
    /// </summary>
    public class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {
        private const decimal TaxWeightMultiplier = 0.0013m;

        public Vehicle()
        {

        }

        public Vehicle(
            int id,
            VehicleType vehicleType, 
            AbstractEngine engine,
            string modelName, 
            string registrationNumber,
            int weight,
            int manufactureYear,
            int mileage,
            Colors carColor)
        {
            Id = id;
            VehicleType = vehicleType;
            Engine = engine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = carColor;
        }

        public int Id { get; set; }
        public List<Rent> Rents { get; set; }
        public double MaxKilometresRange => Engine.GetMaxKilometers(FuelTankSize);
        public AbstractEngine Engine { get; set; }
        public VehicleType VehicleType { get; init; }
        public int ManufactureYear { get; init; }
        public string ModelName { get; init; }
        public int FuelTankSize { get; set; } = 50;
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public Colors Color { get; set; }
        
        public decimal TaxPerMonth => (Weight * TaxWeightMultiplier) + (VehicleType.TaxCoeff * Engine.TaxCoeff * 30) + 5;
        public decimal TotalIncome => Rents.Sum(rent => rent.Cost);
        public decimal TotalProfit => TotalIncome - TaxPerMonth;
        public override string ToString() => $"{ModelName},{RegistrationNumber},{Weight},{Mileage},{Color},{TaxPerMonth:0.00}";

        public int CompareTo(Vehicle other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other), "Other vehicle class can't be null!");
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
