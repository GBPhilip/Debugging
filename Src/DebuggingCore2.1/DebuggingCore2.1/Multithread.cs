using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Domain;

namespace DebuggingCore2._1
{
    public static class MultiThread
    {
        public static void Count(List<AccountHolder> accounts)
        {
            foreach (var holder in accounts)
            {
                
                Thread thread = new Thread(MultiThread.LongCalculation);
                thread.Name = $"Thread-{holder.Name}";
                thread.Start(holder);
             }
        }

        public static void LongCalculation(Object account)
        {
            var accountHolder = (AccountHolder)account;
            Console.WriteLine($"Processing Account for {accountHolder.Name}");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Still Processing Account for {accountHolder.Name}");
            }
            Console.WriteLine($"Finished Processing Account for {accountHolder.Name}");
        }

    }
}

