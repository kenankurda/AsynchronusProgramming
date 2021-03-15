using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task.Factory.StartNew(TypeOfThread).Wait(); // this creates ThreadPool thred
            Task.Factory.StartNew(TypeOfThread, TaskCreationOptions.LongRunning).Wait();

        }

        private static void TypeOfThread()
        {
            Console.WriteLine("This is a {0} thread", Thread.CurrentThread.IsThreadPoolThread ? "ThreadPool" : "CustomThread");
        }
    }
}
