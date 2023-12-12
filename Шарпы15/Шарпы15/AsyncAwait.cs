using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы15
{
    public class AsyncAwait
    {
        public static async Task NewPrint()
        {
            await Printer();
        }
        private static async Task Printer()
        {
            Console.WriteLine("I am async func");
        }

    }
}
