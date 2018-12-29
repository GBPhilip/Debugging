namespace Debugging
{
    using System;
    using System.Diagnostics;

    public class WatchObjectId
    {
        public void ObjectId()
        {
            var localPerson = new Person
            {
                Name = "Fred",
                Age = 31
            };
            Console.WriteLine($"Person called {localPerson.Name} aged { localPerson.Age}");
            var category = DoSomething(localPerson);
            Console.WriteLine($"Person called {localPerson.Name} aged { localPerson.Age} category {category}");

        }











     
        public int DoSomething(Person someone)
        {
            var category = 0;
            if (someone.Age < 20) category = 1;
            if (someone.Age >= 20) category = 2;
            someone.Name = "Albert";
            return category;
        }

    }

    [DebuggerDisplay("Name =  {Name}")]
    public class Person
    {
        public string Name { get; set; }
       
        public int Age { get; set; }
    }


    public class PersonBrowse
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Name { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public int Age { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Road { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public string Town { get; set; }
    }

    [DebuggerTypeProxy(typeof(PersonDebugProxy))]
    public class PersonDebug
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public string CreditCard { get; set; }
    }

    public class PersonDebugProxy
    {
        private readonly PersonDebug personDebug;

        public PersonDebugProxy(PersonDebug personDebug)
        {
            this.personDebug = personDebug;
        }
        public string Name => $"{this.personDebug.FirstName} {this.personDebug.Surname}";
        public string CreditCard => $"{this.personDebug.CreditCard.Substring(0, 4)} **** **** ****";
    }
}