using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventHandle
{
    class Program
    {
        private static readonly ManualResetEvent ExitEvent = new ManualResetEvent(false);


        static void Main(string[] args)
        {
            var thread = new Thread(Program.WorkerThreadFunc);
            thread.Start();
            Thread.Sleep(2000);
            ExitEvent.Set();
            Console.In.ReadLine();
        }


        static void WorkerThreadFunc()
        {
            Console.Out.WriteLine("WorkerThreadFunc start ");
            int times = 1;
            while (!ExitEvent.WaitOne(1000))
            {
                Console.Out.WriteLine("check " + times);
            }

            Console.Out.WriteLine("WorkerThreadFunc end ");
        }

    }
}
