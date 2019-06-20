using Debugging.BasicInterestCalculator;
using Debugging.HighInterestCalculator;
using Debugging.InterestInterface;
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
            return new BasicInterestCalculator();
        }
    }
}