using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using products;
class Programm
{
     static void Main()
    {

        string[] days = { 
        "June",
        "July",
        "Auguhst",
        "September",
        "October",
        "November",
        "December",
        "January",
        "Februrary",
        "March",
        "April",
        "May"
        };


        // 1:
        int n = 4;
        var firstSelect = from d in days
                          where d.Length == n
                          select d;

        firstSelect.ToList();

        foreach(var d in firstSelect)
        {
            Console.Write(d + ' ');

        }
        Console.WriteLine();

        // 1.2:

        string[] daysParts = {
        "Jun",
        "Jul",
        "Aug",
        "Dec",
        "Jan",
        "Feb",
        };
        var secondSelect = from d in days
                           join dp in daysParts on d.Substring(0, 3) equals dp.Substring(0, 3)
                           select d;
                           
        secondSelect.ToList();

  

        foreach (var d in secondSelect)
        {
            Console.Write(d + ' ');
        }
        Console.WriteLine();

        // 3: 

        var thirdSelect = from d in days
                          orderby d ascending
                          select d;

        thirdSelect.ToList();
        foreach (var d in thirdSelect)
        {
            Console.Write(d + ' ');
        }

        // 4:
        Console.WriteLine();
        var fourSelect = (from d in days
                          where d.Contains('u') && d.Length > 4
                          select d).Count();

        Console.Write($"Count: {fourSelect}");

        // 2 task:


        List<Product> list = new List<Product> {
    new Product("Яблоко", "333333", "Пинск", 108.99m, "2023-04-30", 25),
    new Product("Банан", "123131", "Пинск", 1.99m, "2023-04-30", 5),
    new Product("Груша", "14124", "Брест", 5.99m, "2023-04-30", 30),
    new Product("Апельсин", "789456", "Гомель", 3.49m, "2023-04-30", 15),
    new Product("Киви", "654321", "Витебск", 2.79m, "2023-04-30", 20),
    new Product("Персик", "987654", "Могилев", 204.99m, "2023-04-30", 10),
    new Product("Ананас", "456789", "Гродно", 7.99m, "2023-04-30", 8),
    new Product("Манго", "112233", "Полоцк", 6.49m, "2023-04-30", 12),
    new Product("Слива", "445566", "Солигорск", 4.29m, "2023-04-30", 18),
    new Product("Виноград", "778899", "Мозырь", 9.99m, "2023-04-30", 7),
    new Product("Арбуз", "990011", "Орша", 112.99m, "2023-04-30", 3)
};
        Console.WriteLine("--------------------------------------");
        // 3 task: 

        var selectedProducts = (from d in list
                                where d.ProductPrice > 100
                                select d).Count();
        Console.WriteLine("Cost>100 count: " + selectedProducts);
        Console.WriteLine("--------------------------------------");

        Product maxPriceProduct = list.OrderByDescending(p => p.ProductPrice).FirstOrDefault();

        if (maxPriceProduct != null)
        {
            Console.WriteLine("Максимальный товар по цене:");
            Console.WriteLine($"Название: {maxPriceProduct.ProductName}");
            Console.WriteLine($"Цена: {maxPriceProduct.ProductPrice}");
        }
        Console.WriteLine("--------------------------------------");
        var newGroupProducts = from p in list
                               orderby p.ProductCreator 
                               select p;
        foreach (var product in newGroupProducts)
        {
            Console.WriteLine($"Название: {product.ProductName}, Производитель: {product.ProductCreator}, Количество: {product.ProductCount}");
        }

        var productsByCount = list.OrderByDescending(p => p.ProductCount).ThenByDescending(p => p.ProductCreator).ToList();

        foreach (var product in productsByCount)
        {
            Console.WriteLine(product.ProductName + " " + product.ProductCount + " " + product.ProductCreator);
        }
        Console.WriteLine("--------------------------------------");
        // 4 task: 

        var myFullSelect = from p in list
                           where p.ProductCount > 10
                           orderby  p.ProductCreator, p.ProductPrice descending
                           group p by p.ProductCreator into g
                           let avgPrice = g.Average(g => g.ProductPrice)
                           select new
                           {
                               TotalQuantity = g.Sum(g => g.ProductCount),
                               AveragePrice = avgPrice,
                               ProductionPlace = g.Key
                           };

        myFullSelect.ToList();

        foreach(var p in myFullSelect)
        {
            Console.WriteLine(p.AveragePrice + " " + p.TotalQuantity + " " + p.ProductionPlace + ";");
        }

        Console.WriteLine("--------------------------------------");

        // 5 task: 
        List<string> towns = new List<string> {"Минск","Пинск","Гродно" };



        var joinSelect = from p in list
                         join t in towns on p.ProductCreator equals t
                         select p;

        joinSelect.ToList();

        foreach(var p in joinSelect)
        {
            Console.Write(p.ProductName + " " + p.ProductCreator + ";");
        }

        Console.WriteLine();

        List<string> eat = new List<string> { "Яблоко", "Арбуз", "Дыня" };

        var secJoinSelect = list.Join(eat,
            p => p.ProductName,
            c => c,
            (p, c) => new { Name = p.ProductName, Price = p.ProductPrice }
            );

        foreach (var p in secJoinSelect)
        {
            Console.Write(p.Name + " " + p.Price + ";");
        }
        Console.WriteLine();
        Console.WriteLine("--------------------------------------");
    }
}