using Debugging.InterestInterface;
using System;

namespace Debugging.BasicInterestCalculator
{
    public class BasicInterestCalculator : IInterestCalculator
    {
        public int CalculatorSavingsInterest(int balance)
        {
            return (int)(balance * 1.5 / 1);
        }
    }
}
