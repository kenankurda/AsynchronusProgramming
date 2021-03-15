using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersInTask
{
    class Program
    {
        static void Main(string[] args)
        {
           // Task.Factory.StartNew(() => SayHello("Hello Universe")).Wait();

            // call method that retirns a value
            Console.WriteLine("Call a method");

           Task<int> t = Task.Factory.StartNew(() => Calculate(5,2));
            Console.WriteLine("Writing the reult " + t.Result);

        }

        private static void SayHello(string sentence)
        {
            Console.WriteLine(sentence);
        }

        private static int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
