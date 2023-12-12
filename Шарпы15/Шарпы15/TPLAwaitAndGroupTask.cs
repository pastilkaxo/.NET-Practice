using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы15
{
    public class TPLAwaitAndGroupTask
    {

        public static async void CalcThree()
        {
            Task<int> taskA = Task.Run(() => calcA());
            Task<int> taskB = Task.Run(() => calcB());
            Task<int> taskC = Task.Run(() => calcC());

            Task taskFull = new Task(() =>
            {
                int a = taskA.Result;
                int b = taskB.Result;
                int c = taskC.Result;
                int res = a + b + c;
                Console.WriteLine("RES:" + res);
            });
            taskFull.Start();


            Task awaitTask = new Task(async () =>
            {
                int a = await taskA;
                int b = await taskB;
                int c = await taskC;
                int res = a * b + c;
                Console.WriteLine("AWAIT RES: " + res);
            });
            awaitTask.Start();


        }


        public static int calcA()
        {
            int a = 2;
            return a;
        }

        public static int calcB()
        {
            int b = 3;
            return b;
        }

        public static int calcC()
        {
            int c = 4;
            return c;
        }


    }
}
