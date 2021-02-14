using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Models.Base
{
    public class Engine
    {
        public string Type { get; set; }
        public double TaxCoeff { get; set; }
        public int EngineCapacity { get; protected set; }
        public Engine(string type, double coef)
        {
            Type = type;
            TaxCoeff = coef;
        }
    }
}
