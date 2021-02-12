using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPark.Models
{
    public class VehicleType
    {
        public string TypeName { get; set; }
        public double TaxCoef { get; set; }
        public VehicleType()
        {
        }
        public VehicleType(string typeName, double taxCoef)
        {
            TypeName = typeName;
            TaxCoef = taxCoef;
        }

        public void Display()
        {
            Console.WriteLine(
                $"name = {TypeName}\n" +
                $"tax = {TaxCoef}");
        }
        public override string ToString() => $"{TypeName},{TaxCoef}";


    }
}
