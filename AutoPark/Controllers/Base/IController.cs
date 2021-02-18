using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers.Base
{
    /// <summary>
    /// Base interface for controllers
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Method to start controller
        /// </summary>
        void RunController();
    }
}
