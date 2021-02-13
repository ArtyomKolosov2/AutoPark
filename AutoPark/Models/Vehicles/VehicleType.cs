using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPark.Models.Vehicles
{
    public class VehicleType
    {
        public string TypeName { get; set; }
        public double TaxCoeff { get; set; }
        public VehicleType()
        {
        }
        public VehicleType(string typeName, double taxCoeff)
        {
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
