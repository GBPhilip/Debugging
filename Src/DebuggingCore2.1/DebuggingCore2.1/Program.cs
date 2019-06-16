using Debugging.BasicInterestCalculator;
using System;

namespace DebuggingCore2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DivideByZeroException();
        }

        private static void DivideByZeroException()
        {
            var calculator = new BasicInterestCalculator();

            try
            {
                Console.WriteLine($"The interest for an account with £100 is £{calculator.CalculatorSavingsInterest(100)}");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
