namespace Debugging
{
    using System;

    public class Dog : Mammal
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Woff");
        }
    }
}