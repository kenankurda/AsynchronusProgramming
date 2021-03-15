using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MethodCooperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate();
            Console.ReadLine();
        }
        static void Calculate()
        {
            Task.Run(() =>
            {
                Calculate1();
            });

            Task.Run(() =>
            {
                Calculate2();
            });

            Task.Run(() =>
            {
                Calculate3();
            });
        }
        public static int Calculate1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculating result 1 ");
            return 100;
        }
        public static int Calculate2()
        {
            Console.WriteLine("Calculating result 2 ");
            return 200;
        }
        public static int Calculate3()
        {
            Console.WriteLine("Calculating result 3 ");
            return 300;
        }
    }
}
