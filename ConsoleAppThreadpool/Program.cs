using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ConsoleAppThreadpool
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Thread pool Execution");

            stopwatch.Start();
            ProcessWithThreadPoolMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();
            Console.WriteLine("Thread executtion");


            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + stopwatch.ElapsedTicks.ToString());


            /*
             * Start() sætter en tread i gang og det kan tage et object med som peremeter
             * sleep() sætter den tread til at vendte i at bestemt antal ms
             * suspend() Når du kalder Suspend-metoden på en thread 
             *      bemærker systemet at der er anmodet om en thread suspension 
             *      og tillader tråden at udføre indtil den når et sikkert punkt
             *      før den faktisk suspenderes
             * resume() Genoptager en tread der er suspenderet.
             * abort() afbryder den tread den bliver sat på
             * join() stoper opkaldstråden indtil tread der er repræsenteret af denne ikke længer forekomer
             */


            //ThreadPool.QueueUserWorkItem(Process1);

            //ThreadpoolDemo threadpool = new ThreadpoolDemo();
            //for (int i = 0; i <= 2; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(threadpool.task1);
            //    ThreadPool.QueueUserWorkItem(threadpool.task2);
            //}

            //Console.Read();
            Console.ReadKey();
        }

        static void Process1(/*object callback*/)
        // Nej det er ikke nødvendigt med "object callback" fordi metoden ikke har noget den skal have med som peremeter 
        // men hvis man ville bruge QueueUserWorkItem skulle man have object callback med som peremeter
        // QueueUserWorkItem metoden tager et peremeter med som "WaitCallback" og QueueUserWorkItem har ikke et overload så gør at man 
        // passe den uden et peremeter
        {
            //for (int i = 0; i < 100000; i++)
            //{
            //    // mit tilfælje bliver min ProcessWithThreadMethod ligger på 443.802 ms
            //    // hvor imod ProcessWithThreadPoolMethod ligger på 2637 ms
            //}

            //for (int i = 0; i < 100000; i++)
            //{
            //    for (int j = 0; j < 100000; j++)
            //    {
            //        // mit tilfælje bliver min ProcessWithThreadMethod ligger på 4.667.777 ms
            //        // hvor imod ProcessWithThreadPoolMethod ligger på 2337 ms
            //    }
            //}
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process1);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process1);
            }
        }
    }
}
