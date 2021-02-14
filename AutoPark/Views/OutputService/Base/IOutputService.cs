using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService.Base
{
    interface IOutputService<T> where T : class
    {
        public void ShowElementsList(IEnumerable<T> vehicles);
        public void ShowSameElements(IEnumerable<T> vehicles);
    }
}
