using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Task<int> firstTask = Task.Factory.StartNew<int>(() =>
            //      {
            //          Console.WriteLine("First Task");
            //          return 42;
            //      });

            //    Task secondTask = firstTask.ContinueWith((ft) => Console.WriteLine("second Task, firstTask returned {0}", ft.Result));
            //    secondTask.Wait();


            // wait for all tasks or any task to finish

            Task<int>[] tasks = new Task<int>[]
            {
                Task<int>.Factory.StartNew(() =>
                    {
                        Thread.Sleep(5000);
                        return 5;
                    }),

                Task<int>.Factory.StartNew(() =>
                    {
                        Thread.Sleep(1000);
                        return 3;
                    }),

                Task<int>.Factory.StartNew(() =>
                    {
                        Thread.Sleep(4000);
                        return 2;
                    })
            };

            Task.Factory.ContinueWhenAny(tasks, t =>
            {
                Console.WriteLine("ContinueWhenAny");
            });

            Task.Factory.ContinueWhenAll(tasks,(t) =>
            {
                Console.WriteLine("ContinueWhenAll");
            })
            .Wait();
        }
    }
}
