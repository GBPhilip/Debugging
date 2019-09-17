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
            while (true)
            {
                Console.WriteLine("1: ExceptionBreaking");
                Console.WriteLine("2: ModulesExceptionBreaking");
                Console.WriteLine("3: Threads");
                Console.WriteLine("4: DebuggerBrowsable");
                Console.WriteLine("5: DebuggerDisplay");
                Console.WriteLine("6: WatchObjectId");
                Console.WriteLine("7: DemoTasks");
                Console.WriteLine("8: Dump");
                Console.WriteLine("9: ManyThreads");
                Console.WriteLine("10: Parallel Watch");
                Console.WriteLine("11: FloatTest;");
                Console.WriteLine("Enter your option ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ExceptionBreaking();
                        break;
                    case "2":
                        ModulesExceptionBreaking();
                        break;
                    case "3":
                        Threads();
                        break;
                    case "4":
                        DebuggerBrowsableExample();
                        break;
                    case "5":
                        DebuggerDisplay();
                        break;
                    case "6":
                        WatchObjectId();
                        break;
                    case "7":
                        DemoTasks();
                        break;
                    case "8":
                        Dump();
                        break;
                    case "9":
                        ManyThreads();
                        break;
                    case "10":
                        ParallelWatch();
                        break;
                    case "11":
                        FloatTest();
                        break;
                    default:
                        break;
                }
                Console.Write("Continue ....");
                Console.ReadLine();
            }

        }

        private static void FloatTest()
        {
            float a = 100;
                float b = 0;
            var x = a / b;
            Console.WriteLine($"{x}");
        }

        private static void Threads()
        {
            var accounts = GetAccountHolders();


            var account1 = new Account { Balance = 1000, Number = 1111, Holder = GetAccountHolders().First() };
            var account2 = new Account { Balance = 1500, Number = 2222, Holder = accounts.Skip(1).Take(1).First() };
            var x = new List<Account> { account1, account2 };
            var transfer1 = new Transfer { From = account1, To = account2, Amount = 500 };

            var transfer1Caller = new Thread(new ThreadStart(transfer1.ProcessAToB));
            var transfer2Caller = new Thread(new ThreadStart(transfer1.ProcessBToA));
            transfer1Caller.Name = "Process A to B";
            transfer2Caller.Name = "Process B to A";
            transfer1Caller.Start();
            transfer2Caller.Start();
        }

        private static void DemoTasks()
        {
            var accounts = GetAccountHolders();

            var account1 = new Account { Balance = 1000, Number = 1111, Holder = GetAccountHolders().First() };
            var account2 = new Account { Balance = 1500, Number = 2222, Holder = accounts.Skip(1).Take(1).First() };

            var transfer1 = new Transfer { From = account1, To = account2, Amount = 500 };


            var task1 = Task.Run(() =>
            {
                transfer1.ProcessAToB();
            });
            var task2 = Task.Run(() =>
            {
                transfer1.ProcessBToA();
            });
            Task.WaitAll(task1, task2);
            Console.WriteLine("Finished");

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

            accountHolders[0].ChangeRoad("Millfield");
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



        private static List<AccountHolder> GetAccountHolders2()
        {
            return new List<AccountHolder>
            {
                new AccountHolder{Name="Zico", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Philip Jarvis", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Sara Paris", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}},
                new AccountHolder{Name="David", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Ashley", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Mo", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}},
                new AccountHolder{Name="Tasneem", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Jo", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Bob Paris", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}},
                new AccountHolder{Name="Deborah", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Senthil", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Sara Paris", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}},
                new AccountHolder{Name="Charles", Address = new Address{Road = "High Street", Town = "Cardiff"} },
                new AccountHolder{Name = "Zac", Address = new Address{Road = "Main Street", Town = "Ludlow"}},
                new AccountHolder{Name = "Poppy", Address = new Address{Road = "Aston Lane", Town = "Newport Pagnell"}}
            };
        }

        private static void WatchObjectId()
        {
            var newHolder = ChangeHolder();
        }

        private static string ChangeHolder()
        {
            var current = new Account { Balance = 100, Number = 1111, Holder = GetAccountHolders().First() };
            var changeHolder = GetAccountHolders().Skip(1).Take(1).First();
            var current1 = current;

            current1.ChangeHolder(changeHolder);
            return changeHolder.Name;

        }

        private static  void Dump()
        {
            var accounts = GetAccountHolders();
            Console.WriteLine("You can take a process dump");
            Console.ReadLine();
        }

        private static void ManyThreads()
        {
            var accounts = GetAccountHolders();
            MultiThread.Count(accounts);
        }

        private static void ParallelWatch()
        {
            var accounts = GetAccountHolders2();
            Parallel.ForEach(accounts, (account) =>
           {
               Console.WriteLine($"Name = {account.Name}");
               Console.WriteLine($"Road = {account.Address.Road}");

           });
        }
    }
}
