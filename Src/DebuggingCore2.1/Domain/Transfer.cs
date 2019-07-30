using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Domain
{
    public class Transfer
    {
        object lock1 = new Object();
        object lock2 = new Object();

        public Account From { get; set; }
        public Account To { get; set; }

        public int Amount { get; set; }

        public Transfer(Account From, Account To, int Amount)
        {
            this.From = From;
            this.To = To;
            this.Amount = Amount;
        }

        public Transfer()
        {
        }

        public void ProcessAToB()
        {

            lock (lock1)
            {
                From.DecreaseBalance(500);
                Thread.Sleep(5000);
                lock (lock2)
                {
                    To.IncreaseBalance(500);
                }
            }
        }

        public void ProcessBToA()
        {
            lock (lock2)
            {
                From.DecreaseBalance(200);
                Thread.Sleep(5000);
                lock (lock1)
                {
                    To.IncreaseBalance(200);
                }
            }
        }
    }

    public class A
    {
        public static void Count()
        {
            var job = new ThreadStart(ThreadUpJob);
            var thread = new Thread(job);
            thread.Name = "CountUp";
            thread.Start();
            for (var down = 100; down > 0; down--)
            {
                Console.WriteLine($"Countdown {down}");
                Thread.Sleep(500);
            }
        }

        private static void ThreadUpJob()
        {
            for (var up = 0; up < 100; up++)
            {
                Console.WriteLine($"Countup {up}");
                Thread.Sleep(500);
            }
        }
    }
 }
