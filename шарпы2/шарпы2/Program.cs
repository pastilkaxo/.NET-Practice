using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using products;


class Programm
{
    static void Main()
    {


        Product prdTest = new Product();
        prdTest.PrintProduct();
        
        Console.WriteLine("Введите имя продукта:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите UPC:");
        string upc = Console.ReadLine();

        Console.WriteLine("Введите производителя:");
        string creator = Console.ReadLine();

        Console.WriteLine("Введите цену:");
        decimal price;
        price = Convert.ToDecimal(Console.ReadLine());  

        Console.WriteLine("Введите срок хранения (дата в формате ГГГГ-ММ-ДД):");
        string date = Console.ReadLine();

        Console.WriteLine("Введите количество:");
        int count;
        count = Convert.ToInt32(Console.ReadLine()); 


        Product product1 = new Product( name, upc, creator,price,date, count);
        Product product2 = new Product("Яблоко","333333" ,"Пинск",8.99m,"2023-04-30",25);
        Product product3 = new Product("Арбуз", "444444", "Брест", 14.99m, "2023-03-21", 55);

        Console.WriteLine(product1 == product2);

        Product.DisplayObjectsInfo();

        // equal

        Console.WriteLine($"p1 with p2 : {product1.Equals(product2)}");
        Console.WriteLine($"p2 with p2 : {product2.Equals(product2)}");

        Console.WriteLine(" ");

        // ref,out

        int newCount = 30;
       
        product1.NewProductCount(ref newCount, out count);
        Console.WriteLine($"Old Value: {count} New Value: {newCount}");
        Console.WriteLine($"p1 count: {product1.ProductCount}");
        Console.WriteLine(" ");


      
        // p info
        Console.WriteLine("P1 info:\n");
        product1.PrintProduct();
        Console.WriteLine(" ");

        // obj array

        Product[] products = { product1, product2, product3 };

        // вывод инфы по названию

        string pName;
        Console.WriteLine("Введите имя продукта который хотите найти:");
        pName = Console.ReadLine();
      
        foreach(var item in products)
        {
            if (item.ProductName.Equals(pName))
            {
                item.PrintProduct();
            }
          
        }   


        Console.WriteLine(" ");
        // вывод информации о продуктах с ценой не превышающей 10

        decimal maxPrice = 10.00m;
        string pNameSec;
        Console.WriteLine("Введите имя продукта который хотите найти с ценой ниже 10:");
        pNameSec = Console.ReadLine();

        foreach (var product in products)
        {
            if(product.ProductPrice <= maxPrice && product.ProductName.Equals(pNameSec))
            {
                product.PrintProduct();
            }
           
        }

        Console.WriteLine(" ");
        // анонимный тип

        var anonProduct = new { ProductName = "AnonimP" , ProductCount = 10 };
        Console.WriteLine($"ANONIM : Type: {anonProduct.ToString()}");


        Console.WriteLine(" ");



        // HASH,toString,equals

        Console.WriteLine($"HASH: {product2.GetHashCode()}");
        Console.WriteLine($"toString: {product1.ToString()}");
        Console.WriteLine($"Equals: {product3.Equals(product1)}");

        void Sum()
        {
            decimal totalSum = 0;
            foreach(var product in products)
            {
                totalSum += product.ProductPrice;
                
            }
            Console.WriteLine(totalSum);
        }
        Sum();

        






    }
}
