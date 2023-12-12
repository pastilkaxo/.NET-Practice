using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Шарпы15
{
    public class TPLTask
    {

        public static  void CalculateTasks()
        {
            Task task3 = new Task(() => FindSimpleNumbersWithCancel());
            task3.Start();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task task1 =  new Task(() => FindSimpleNumbers());
            task1.Start();
            Console.WriteLine($"ID: {task1.Id}");
   
            Console.WriteLine("Task1 starts");
            Thread.Sleep(1000);
            Console.WriteLine($"Task Status: {task1.Status}");


            while (!task1.IsCompleted)
            {
                Console.WriteLine("Задача не завершена");
               Thread.Sleep(1500);
            }
            if (task1.IsCompleted)
            {
                Console.WriteLine("Задача  завершена");
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
       ts.Hours, ts.Minutes, ts.Seconds,
       ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }
            
          

        }


        static void FindSimpleNumbers()
        {
            int[] eratosphen = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            int[] primes = FindPrimes(eratosphen);

          
            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }

        }


        static public void FindSimpleNumbersWithCancel()
        {
               int[] eratosphen = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

        int[] primes = FindPrimes(eratosphen);

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            foreach (int prime in primes)
        {
                Task task2 = new Task(() => Console.WriteLine(prime), cancellationToken);
                task2.Start();
                Thread.Sleep(1000);
                cts.Cancel();

                cts.Dispose();

                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
            }

        }

        static int[] FindPrimes(int[] numbers)
        {
            List<int> primes = new List<int>();

            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }

            return primes.ToArray();
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }







    }
}
