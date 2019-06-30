using Debugging.BasicInterestCalculator;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DebuggingCore2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ExceptionBreaking();
            //ModulesExceptionBreaking();
            //DebuggerBrowsableExample();
            //DebuggerDisplay();
            //WatchObjectId();
            Threads();
        }

        private static void Threads()
        {
            var accounts = GetAccountHolders();

            var account1 = new Account { Balance = 1000, Number = 1111, Holder = GetAccountHolders().First() };
            var account2 = new Account { Balance = 1500, Number = 2222, Holder = accounts.Skip(1).Take(1).First() };

            var transfer1 = new Transfer { From = account1, To = account2, Amount = 500 };
   
            var transfer1Caller = new Thread(new ThreadStart(transfer1.ProcessAToB));
            var transfer2Caller = new Thread(new ThreadStart(transfer1.ProcessBToA));
            transfer1Caller.Start();
            transfer2Caller.Start();

            Console.WriteLine($"Balance of account 1 is {account1.Balance} and of account2 is {account2.Balance}");
        }

        private static void DebuggerBrowsableExample()
        {
            throw new NotImplementedException();
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
                var x = 10;
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
            var aBoolean = false;
            var accountHolders = GetAccountHolders();
            if (accountHolders.Count == 3)
            {
                var displaySomething = "Autos";
            }

            if (aBoolean)
            {
                accountHolders = null;
            }
        }

        private static List<AccountHolder> GetAccountHolders()
        {
            return new List<AccountHolder>
            {
                new AccountHolder{Name="Zico", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Philip Jarvis", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Sara Paris", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}}
            };
        }

        private static void WatchObjectId()
        {
            var current = new Account { Balance = 100, Number = 1111, Holder = GetAccountHolders().First() };
            var changeHolder = GetAccountHolders().Skip(1).Take(1).First();
            current.ChangeHolder(changeHolder);

        }
    }
}
