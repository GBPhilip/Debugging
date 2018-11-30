namespace Debugging
{
    using System;

    public class BreakHitFunctionality
    {
        public static void Process(int i)
        {
            if (i == 200)
            {
                throw new Exception("Oh dear this failed");
            }
        }

        private int PrivateMethod(int g)
        {
            return g + 50;
        }
    }
}