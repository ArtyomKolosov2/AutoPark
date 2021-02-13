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
        public double EngineTaxCoef { get; set; }
        public Engine(string type, double coef)
        {
            Type = type;
            EngineTaxCoef = coef;
        }
    }
}
