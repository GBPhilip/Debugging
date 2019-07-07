using System;
using Debugging.InterestInterface;

namespace NugetCalculator
{
    public class CalculatorIndependant :IInterestCalculator
    {
        public int CalculatorSavingsInterest(int balance)
        {
            return (int)(balance * 5.5 / 1);
        }
    }
}
