using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Шарпы11;
using System.Reflection.Emit;

class Programm
{
    static void Main()
    {
        ReflectorTest("products.Product, шарпы2");
        ReflectorTest("Programmer, Шарпы8");
        Console.WriteLine("--------------------------------------");
        ReflectorTest("System.Object");
        ReflectorTest("System.String");

        Console.WriteLine("--------------------------------------");
        products.Product pr = new products.Product("Яблоко", "333333", "Пинск", 108.99m, "2023-04-30", 25);
        Console.WriteLine($"Before Invoke: {pr}");
        Reflector.Invoke(pr, "PrintProduct", null);


        Reflector.InputFile("products.Product, шарпы2");
        
        Console.WriteLine("--------------------------------------");
        products.Product pr2 = Reflector.Create<products.Product>("products.Product, шарпы2" , new object[] { "Vladislav", "#####", "Vlad", 108.99m, "2023-04-30", 25 });
        pr2.PrintProduct();    
    }
  
    static void ReflectorTest(string typeName)
        
    {
        Console.WriteLine(typeName);
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Gettype: "+ Reflector.GetType(typeName));
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("HasPublicConstructors: " + Reflector.HasPublicConstructors(typeName));
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"GetPublicMethods:\n{string.Join("\n", Reflector.GetPublicMethods(typeName))}");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"GetPublicFields:\n{string.Join("\n", Reflector.GetFields(typeName))}");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"GetInters:\n{string.Join("\n",Reflector.GetInters(typeName))}");
        Console.WriteLine("--------------------------------------");
        //Console.WriteLine($"GetMethodWithParametr:\n{string.Join("\n", Reflector.GetMethodWithParametr(typeName, "String"))}");
          Console.WriteLine("--------------------------------------");
    }
}

