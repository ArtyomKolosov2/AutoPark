﻿using AutoPark.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Views.OutputService.Base
{
    public interface IOutputService
    {
        public void ShowStringWithLineBreak(string message);
        public void ShowStringWithoutLineBreak(string message);
        public void ShowVehicleList(IEnumerable<Vehicle> elements);
        public void ShowSameVehicles(IEnumerable<Vehicle> elements);
    }
}
