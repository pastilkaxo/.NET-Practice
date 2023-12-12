using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using System.IO;
using System.Threading;

class Programm
{

    static void Main()
    {
        // 1:  

        foreach (Process pr in Process.GetProcesses())
        {
            Console.WriteLine($"ID: {pr.Id}\t {pr.SessionId}\t | {pr.ProcessName}\t | {pr.BasePriority}");
        }

        Console.WriteLine("--------------------------------------");

        //2 :

        AppDomain dom = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {dom.FriendlyName} Conf: {dom.SetupInformation} Packs: \n");
        Assembly[] assemblies = dom.GetAssemblies();
        foreach (Assembly asm in assemblies)
        {
            Console.WriteLine(asm.GetName().Name);
        }

        Console.WriteLine("--------------------------------------");
        // 3: 
        int n;

        Console.WriteLine("Write n: ");
        n = int.Parse(Console.ReadLine());

        string filePath = "C:\\Users\\Влад\\source\\repos\\Шарпы14\\Шарпы14\\Numbers";

        Thread th1 = new Thread(() => WriteI(filePath , n));
        th1.Name = "OddNumbers";

        th1.Start();
        th1.Join();

        Thread th2 = new Thread(() => WriteII(filePath , n));
        th2.Name = "EvenNumbers";
        th2.Priority = ThreadPriority.BelowNormal;


        th2.Start();
        th2.Join();


        Thread th3 = new Thread(() => WriteIWithTimer());
        th3.Start();
        th3.Join();

    }


   static void WriteI(string basePath , int n)
    {
        object locker = new();

        using(StreamWriter sw = new StreamWriter(Path.Combine(basePath, "iNumbers.txt")))
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                for (int i = 1; i < n; i += 2)
                {
                    sw.WriteLine(i);
                    Console.WriteLine($"i even: {i}");
                    Thread.Sleep(500);
                }


                for (int i = 2; i < n; i += 2)
                {
                    sw.WriteLine(i);
                    Console.WriteLine($"i odd: {i}");
                    Thread.Sleep(500);
                }


            }
            finally
            {
                if(acquiredLock) Monitor.Pulse(locker);
            }
        
                Thread.Sleep(500);
        }

    }


    static void WriteII(string basePath, int n)
    {
        object locker = new();

        using (StreamWriter sw = new StreamWriter(Path.Combine(basePath, "iiNumbers.txt")))
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                for (int i = 1, j = 2; i < n || j < n; i += 2, j += 2)
                {
                    if (i < n)
                    {
                        sw.WriteLine(i);
                        Console.WriteLine($"ii even: {i}");
                        Thread.Sleep(500);
                    }

                    if (j < n)
                    {
                        sw.WriteLine(j);
                        Console.WriteLine($"ii odd: {j}");
                        Thread.Sleep(500);
                    }
                }

            }
            finally
            {
                if (acquiredLock) Monitor.Exit(locker);
            }

            Thread.Sleep(500);
        }

    }

    public static void Printer(object x)
    {
        int c = (int)x;
        for(int i = 0; i < 10; i++)
        {
            c++;
            Console.WriteLine($"Число увеличено:{c}");
        }
    }

    static void WriteIWithTimer()
    {
        int num = 5;
        TimerCallback tm = new TimerCallback(Printer);
        Timer time = new Timer(tm,num,0,5000);

    }

}