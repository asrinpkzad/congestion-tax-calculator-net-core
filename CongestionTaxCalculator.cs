using System;
using congestion.calculator;
public class CongestionTaxCalculator
{
    private readonly ITaxRule _taxRule;

    public CongestionTaxCalculator(ITaxRule taxRule)
    {
        _taxRule = taxRule;
    }
    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        if (vehicle.IsExempt) return 0;

        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = _taxRule.GetTollFee(date);
            int tempFee = _taxRule.GetTollFee(intervalStart);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }
}
