using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator
{
    public interface ITaxRule
    {
        int GetTollFee(DateTime dateTime);
        bool IsTollFreeDate(DateTime dateTime);
    }
}
