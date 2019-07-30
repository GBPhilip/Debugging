using Debugging.BasicInterestCalculator;
using Debugging.HighInterestCalculator;
using Debugging.InterestInterface;
using NugetCalculator;
using System;

namespace DebuggingCore2._1
{
    internal class CalculatorFactory
    {
        public CalculatorFactory()
        {
        }

        internal IInterestCalculator GetInterestCalculator(string calculatorPicker)
        {
            if (calculatorPicker == "H")
            {
                return new HighInterestCalculator();
            };
            if (calculatorPicker == "N")
            {
                return new CalculatorIndependant();
            };
            return new BasicInterestCalculator();
        }
    }
}