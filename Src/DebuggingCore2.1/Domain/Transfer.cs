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
}
