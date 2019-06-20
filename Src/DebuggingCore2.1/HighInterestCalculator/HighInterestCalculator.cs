using Debugging.InterestInterface;
using System;

namespace Debugging.HighInterestCalculator
{
    public class HighInterestCalculator : IInterestCalculator
    {
        public int CalculatorSavingsInterest(int balance)
        {
             return (int)(balance * 1.5 / 0);
        }
    }
}
