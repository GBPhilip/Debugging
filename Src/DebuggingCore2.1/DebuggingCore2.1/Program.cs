using Debugging.BasicInterestCalculator;
using Domain;
using System;
using System.Collections.Generic;

namespace DebuggingCore2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ExceptionBreaking();
            //ModulesExceptionBreaking();
        }

        private static void ExceptionBreaking()
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

        private static void ModulesExceptionBreaking()
        {
            Console.WriteLine("Basic (B) or High (H) interest calculation");
            var calculatorPicker = Console.ReadLine();
            try
            {
                var interestCalculator = new CalculatorFactory().GetInterestCalculator(calculatorPicker);
                var x = interestCalculator.CalculatorSavingsInterest(100);
            }
            catch
            {
                Console.WriteLine("In the catch");
            }
        }

        private static void DebuggerDisplay()
        {
            var accountHolders = new List<AccountHolder>
            {
                new AccountHolder{Name="Zico"},
                new AccountHolder{Name = "Philip Jarvis"},
                new AccountHolder{Name = "Sara Paris"}
            };
        }
    }
}
