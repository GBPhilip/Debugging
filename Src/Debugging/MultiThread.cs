namespace Debugging
{
    using System;
    using System.Threading;

    internal static class MultiThread
    {
        internal static void Count()
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