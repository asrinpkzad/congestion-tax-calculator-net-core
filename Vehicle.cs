using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public interface Vehicle
    {
        bool IsExempt { get; }
        string GetVehicleType();
    }
}