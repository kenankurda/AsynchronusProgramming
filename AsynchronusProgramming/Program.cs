using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronusProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // SayHello();
            //Task t = new Task(SayHello); // first way to start a task
            //t.Start();
            //t.Wait();

            //Task t = Task.Run(SayHello);
            //t.Wait();

            Task t = Task.Factory.StartNew(SayHello);
            t.Wait();
           
        }

        private static void SayHello()
        {
            Console.WriteLine("Hello world");
        }
    }
}
