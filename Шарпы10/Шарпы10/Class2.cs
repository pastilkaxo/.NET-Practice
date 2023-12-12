using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products;
internal partial class Product
{

    public int ProductID
    {
        get { return ID; }
    }
    public string ProductName { get; set; }
    public string UPC { get; set; }
    public string ProductCreator { get; set; }
    public decimal ProductPrice { get; set; }
    public string UsingTime { get; set; }

    private int productCount;


    public int ProductCount
    {
        get { return productCount; }
        private set
        {
            if (value >= 0)
            {
                productCount = value;
            }
            else
                Console.WriteLine("ERROR!");
        }
    }


    static Product()
    {
        Console.WriteLine($"Category: {Category}");
    }

    private Product()
    {
        ID = idCounter++;
        totalObjects++;
    }



    public Product(string name = "Unknown", string upc = "000000", string creator = "Unknown", decimal price = 0,
        string date = "2023-01-01", int pCount = 0) : this()
    {
        ProductName = name;
        UPC = upc;
        ProductPrice = price;
        ProductCreator = creator;
        UsingTime = date;
        ProductCount = pCount;

    }



    public static void DisplayObjectsInfo()
    {
        Console.WriteLine("Класс Product:");
        Console.WriteLine($"OBJECTS COUNT: {totalObjects}");

    }

    public void NewProductCount(ref int newCount, out int oldCount)
    {
        oldCount = 0;
        ProductCount += newCount;

    }




    public void PrintProduct()
    {
        Console.WriteLine($"Product ID: {ProductID} \n  Name:{ProductName} \n " +
            $"UPC:{UPC} \n Price:{ProductPrice} \n Creator: {ProductCreator} \n Time: {UsingTime} \n Count: {ProductCount}");
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Product otherProduct = (Product)obj;
        return ID == otherProduct.ID;
    }

    public override int GetHashCode()
    {

        return ID.GetHashCode();
    }

    public override string ToString()
    {
        return $" Type: {base.ToString()},  ID: {ProductID}; Name: {ProductName}; Price:{ProductPrice}; Count:{ProductCount};";
    }


}

