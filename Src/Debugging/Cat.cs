namespace Debugging
{
    using System;

    public class Cat : Mammal
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }
}