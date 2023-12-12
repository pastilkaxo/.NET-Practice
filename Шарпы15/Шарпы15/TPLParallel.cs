using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Шарпы15
{
    public class TPLParallel
    {
        public static void ParallelForAndForEach()
        {
            string[] strings = { "Lemiasheusky", "Vladislav", "Olegovich" };
            string replaceString = "BSTU";

            Parallel.For(0, strings.Length, i =>
            {
                TextFormatter(strings, replaceString, i);
            });

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i] + " ");
            }


        }

        public static void TextFormatter(string[] strings, string replaceString, int i)
        {
            strings[i] = replaceString;

        }

        public static void ParallelForEach()
        {
            List<string> strings = new List<string> { "Lemiasheusky", "Vladislav", "Olegovich" };
            string replaceString = "ABOB";

            ParallelLoopResult result = Parallel.ForEach(strings, s =>
            {
                TextFormatter2(strings, replaceString, s);
            });

            // Обработка результата, если необходимо
            if (result.IsCompleted)
            {
                Console.WriteLine("Все элементы обработаны успешно.");
            }
            else
            {
                Console.WriteLine("Обработка завершена с ошибкой. Некоторые элементы могли остаться необработанными.");
            }

            // Вывести результат
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }

   
        public static void TextFormatter2(List<string> strings, string replaceString, string s)
        {
            strings.RemoveAt(0);
            strings.Add(replaceString);

        }

        public static void ParallelFewTasks()
        {
            Parallel.Invoke(() => {
                Console.WriteLine("A");
            }, () => {
                Console.WriteLine("B");
            }
       );
        }

    }
}
