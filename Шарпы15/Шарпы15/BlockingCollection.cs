using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы15
{
    internal static class BlockingCollection
    {
        static BlockingCollection<string> _warehouse = new BlockingCollection<string>();

        public static void RefreshShop()
        {
            Task[] suppliers = new Task[5];
            Task[] customers = new Task[10];

            for (int i = 0; i < suppliers.Length; i++)
            {
                suppliers[i] = Task.Run(Supplier);
            }

            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = Task.Run(Customer);
            }

            Task.WaitAll(suppliers);
            _warehouse.CompleteAdding();
            Task.WaitAll(customers);
        }

        private static void Supplier()
        {
            string[] products = { "Apple", "Banana", "Orange" };
            Random random = new Random();

            foreach (string product in products)
            {
                Thread.Sleep(random.Next(1000, 3000));

                _warehouse.Add(product);
                Console.WriteLine($"New Item: {product}");
                PrintWarehouseContents();
            }
        }

        private static void Customer()
        {
            Random random = new Random();

            while (!_warehouse.IsCompleted)
            {
                Thread.Sleep(random.Next(500, 2000));

                string? product = null;

                if (_warehouse.TryTake(out product))
                {
                    Console.WriteLine($"ITEM: {product}");
                    PrintWarehouseContents();
                }
                else
                {
                    Console.WriteLine("No this item");
                }
            }
        }

        private static void PrintWarehouseContents()
        {
            Console.WriteLine("All Items " + string.Join(", ", _warehouse));
        }
    }
}

