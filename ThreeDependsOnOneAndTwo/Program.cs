using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeDependsOnOneAndTwo
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
            var task1 = Task.Run(() =>
            {
                return Calculate1();
            });

            var task2 = Task.Run(() =>
            {
                return Calculate2();
            });

            Task.WaitAll(task1, task2);

            var awaiter1 = task1.GetAwaiter();
            var awaiter2 = task2.GetAwaiter();

            var result1 = awaiter1.GetResult();
            var result2 = awaiter2.GetResult();

            Calculate3(result1, result2);
            // or

            //Calculate3(awaiter1.GetResult(), awaiter2.GetResult());

        }
        public static int Calculate1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculating result 1 ");
            return 50;
        }
        public static int Calculate2()
        {
            Console.WriteLine("Calculating result 2 ");
            return 10;
        }
        public static int Calculate3(int result1, int result2)
        {
            var result = result1 + result2;
            Console.WriteLine("Calculating result 3 " + result);
            return result;
        }
    }
}
