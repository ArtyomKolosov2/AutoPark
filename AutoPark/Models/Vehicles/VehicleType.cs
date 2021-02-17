using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPark.Models.Vehicles
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public decimal TaxCoeff { get; set; }
        public VehicleType()
        {
        }
        public VehicleType(int id, string typeName, decimal taxCoeff)
        {
            Id = id;
            TypeName = typeName;
            TaxCoeff = taxCoeff;
        }

        public void Display()
        {
            Console.WriteLine(
                $"name = {TypeName}\n" +
                $"tax = {TaxCoeff}");
        }
        public override string ToString() => $"{TypeName},{TaxCoeff}";


    }
}
