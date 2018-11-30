namespace Debugging
{
    using System;

    public class MyMaths
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public int Add()
        {
            return Number1 + Number2;
        }
        public int Subtract()
        {
            return Number1 - Number2;
        }
        public int Multiply()
        {
            return Number1 * Number2;
        }
        public int Divide()
        {
            try
            {
                return Number1 / Number2;
            }
            catch (Exception)
            {

                return -9999;
            }
        }
    }
}