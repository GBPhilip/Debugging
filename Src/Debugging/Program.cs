namespace Debugging
{
    using Ploeh.AutoFixture;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Visualisers;
   
    
   
    using System.Threading.Tasks;

    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)


        {
            while (true)
            {
                Menu();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("1: Locals");
            Console.WriteLine("2: Auto return values");
            Console.WriteLine("3: Exceptions");
            Console.WriteLine("4: Exceptions With Conditions");
            Console.WriteLine("5: Breakpoints With Conditions");
            Console.WriteLine("6: Break hit functionality");
            Console.WriteLine("7: Object Id");
            Console.WriteLine("8: Break on return");
            Console.WriteLine("9: Break at function");
            Console.WriteLine("10: Dump");
            Console.WriteLine("11: Intellitrace");
            Console.WriteLine("12: Project Options");
            Console.WriteLine("13: Debugger Display");
            Console.WriteLine("14: Debugger Browsable");
            Console.WriteLine("15: Debugger Proxy");
            Console.WriteLine("16: Threading");
            Console.WriteLine("17: Parallel");
            Console.WriteLine("18: Visualisers");
            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    {
                        Locals();
                        break;
                    }

                case "2":
                    {
                        Autos();
                        break;
                    }
                case "3":
                    {
                        Exceptions();
                        break;
                    }
                case "4":
                    {
                        Conditions();
                        break;
                    }
                case "5":
                    {
                        ConditionalBreakpoints();
                        break;
                    }
                case "6":
                    {
                        WhenHit();
                        break;
                    }
                case "7":
                    {
                        var watchObjectId = new WatchObjectId();
                        watchObjectId.ObjectId();
                        break;
                    }
                case "8":
                    {
                        var refNum = 8;
                        var answer = refNum + SomethingSilly(ref refNum);
                        refNum = 8;
                        var answer2 = SomethingSilly(ref refNum) + refNum;
                        break;
                    }
                case "9":
                    {
                        new Sheep().MakeNoise();
                        new Dog().MakeNoise();
                        new Cat().MakeNoise();
                        break;
                    }
                case "10":
                    {
                        Dump(selection);
                        break;
                    }
                case "11":
                    {
                        Intellitrace();
                        break;
                    }
                case "12":
                    {
                        ProjectOptions();
                        break;
                    }
                case "13":
                    {
                        DebuggerDisplay();
                        break;
                    }
                case "14":
                    {
                        DebuggerBrowsable();
                        break;
                    }
                case "15":
                    {
                        DebuggerProxy();
                        break;
                    }
                case "16":
                    {
                        Threading();
                        break;
                    }
                case "17":
                    {
                        ParallelExample();
                        break;
                    }
                case "18":
                {
                    VisualiserDemo();
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void VisualiserDemo()
        {
            var exampleString = "Hello World";
      //      StringDebuggerVisualiser.TestShowVisualizer(exampleString);
        }
        private static void ParallelExample()
        {
            var names = new List<string> { "Bob", "Judy", "Chris", "Ashley" };
            Parallel.ForEach(names, (name) =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Hello {name} {i}");
                }
            });

        }

        private static void Threading()
        {
            MultiThread.Count();
        }

        private static void DebuggerDisplay()
        {
            var person1 = new Person { Name = "Bob" };
            var person2 = new Person { Name = "Jane" };
            var person3 = new Person { Name = "Thelma"};
            var person4 = new Person { Name = "Mo" };
            var person5 = new Person { Name = "Uma" };
            
            var persons = new List<Person>{person1, person2, person3, person4, person5};
            var fixture = new Fixture();
            fixture.Customize<Person>(e => e.With(x => x.Name, GenerateName()));
            var p = fixture.CreateMany<Person>(5).ToList();
        }

        private  static string GenerateName()
        {
            var names= new List<string>{"Bob", "Judy", "Fred", "Jayne", "Chris", "Sakina", "Tasneem"};
            return names[random.Next(0, 5)];
        }


        private static void DebuggerBrowsable()
        {
            var address = new Address { Road = "High Street", Town = "Newport Pagnell" };
            var person = new PersonBrowse { Name = "fred", Age = 20, Address = address };
        }

        private static void DebuggerProxy()
        {
            var person = new PersonDebug { FirstName = "Freda", Surname = "Smith", CreditCard = "1234 5678 1234 5678"};
        }
        private static void ProjectOptions()
        {
            byte counter = 0;
            while (true)
            {
                Console.WriteLine($"Count is {counter})");
                counter++; 
            }
        }

        private static void Intellitrace()
        {
            Console.Write("Number 1 ");
            var number1 = int.Parse(Console.ReadLine());
            Console.Write("Number 2 ");
            var number2 = int.Parse(Console.ReadLine());
            Console.Write("Number 3 ");
            var number3 = int.Parse(Console.ReadLine());
            Console.Write("Number 4 ");
            var number4 = int.Parse(Console.ReadLine());
            Console.Write("Number 5 ");
            var number5 = int.Parse(Console.ReadLine());
            var myClass = new MyMaths();
            myClass.Number1 = number1;
            myClass.Number2 = number2;
            myClass.Number1 = myClass.Add();
            myClass.Number2 = number3;
            myClass.Number1 = myClass.Divide();
            myClass.Number2 = number4;
            myClass.Number1 = myClass.Multiply();
            myClass.Number2 = number5;
            myClass.Number1 = myClass.Subtract();

            Console.WriteLine("The answer is {0}", myClass.Number1);
            Console.ReadLine();
        }

        private static void Dump(string selectionPassed)
        {
            byte x = 255;
            x++;
             var person = new Person { Age = 35, Name = "Ashley" };
            var message = "doing something";
            Console.WriteLine($"{message}{selectionPassed}");
            Console.ReadLine();
            Console.WriteLine($"Age is {person.Age}");
        }

        private static void Exceptions()
        {
            try
            {
                var result = new Calculator2.Calculator().Divide(5, 0);

            }
            catch (Exception)
            {
                Console.WriteLine("Whoops");
            }
            Console.WriteLine("End of conditions");

        }
        static void Conditions()
        {
            try
            {
                var result1 = new Calculator1.Calculator().Divide(5, 0);
            }
            catch (Exception)
            {
                Console.WriteLine("Calculator 1");
            }
            try
            {
                var result2 = new Calculator2.Calculator().Divide(5, 0);
            }
            catch (Exception)
            {
                Console.WriteLine("Calculator 2");
            }
            Console.WriteLine("The result is something");
        }

        private static void Autos()
        {
            var total = method1() + method2();
            Console.WriteLine($"The result is {total}");

        }

        static int method1()
        {
            return 5 + 4;
        }

        static int method2()
        {
            return 3 + 2;
        }

        static void Locals()
        {
            var first = 6;
            var second = 0;
            var divide = Maths.Divide(first, second);
            Console.WriteLine($"Divide gives {divide}");
        }

        private static void ConditionalBreakpoints()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"The value is {i}");
            }
        }

        private static void WhenHit()
        {
            for (var i = 0; ; i++)
            {
                BreakHitFunctionality.Process(i);
            }
        }

        public static int SomethingSilly(ref int x)
        {
            x = 1;
            return 2;
        }

    }
}
