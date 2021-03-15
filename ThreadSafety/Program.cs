using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafety
{
    class Program
    {
        static int balance;
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            List<Task> tasks = new List<Task>();
            int x = 1;
            //object _lock = new object();
            
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        //lock (_lock)
                        //{
                        //    account.Balance++;
                        //    balance = balance + 1
                        //}

                        //Interlocked.Increment(ref balance);
                        //Interlocked.Decrement(ref balance);
                        Interlocked.Add(ref balance, x);

                    }
                }));
            }

            

            Task.WaitAll(tasks.ToArray());
            account.Balance = balance;

            //Console.WriteLine("Expected value 10000  actual value : " + account.Balance);
            //Console.WriteLine("Expected value 10000  actual value : " + balance);
            //Console.WriteLine("Expected value 10000  actual value : " + balance);
            Console.WriteLine("Expected value 10000  actual value : " + balance);


        }
    }
}
