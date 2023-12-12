// Квитанция, Накладная, Документ, Чек, Дата, Организация.

using printer;
using accounting;
using System.Reflection;
using exceptions;
using System.Diagnostics;

public abstract class Document
{
    private int BaseId;
    public string Title { get; set; }
    public int Number { get; set; }

    public override string ToString()
    {
        return $"Type: {base.GetType()} Title: {Title}, Number: {Number}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Document otherDocument = (Document)obj;
        return this.Title == otherDocument.Title && this.Number == otherDocument.Number;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }


    public virtual void ShowInformation()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Number: {Number}");
    }

    public void ClassDetection()
    {
        Console.WriteLine("Type of Document:" + base.ToString());
    }
}


public interface IContainsDate
{
    DateTime Date { get; set; }
    void SetDate(DateTime date);

    void ClassDetection();
    string ToString();
}


public class NewDate : IContainsDate
{
    public DateTime Date { get; set; }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    public void ClassDetection()
    {
        Console.WriteLine("Type of Date:" + base.ToString());
    }

    public string ToString()
    {
        return $"Type: {base.GetType()} Date: {Date}";
    }

}


public struct Address
{
    public string Country { get; set; }
    public string City { get; set; }
}


public class Organization
{
    public string OrgName { get; set; }
    public Address Place { get; set; }
    public Organization(string name)
    {
        OrgName = name;
    }


    public override string ToString()
    {
        return $"Type: {base.GetType()} OrgName: {OrgName} , Adress: {Place}";
    }

}



public enum RecieptType
{
    Paid,
}



public sealed class Receipt : Document, IContainsDate
{

    private int ID { get; set; }

    public int rID
    {
        get { return ID; }
    }

    int idCounter = 1;

    public decimal TotalAmount { get; set; }
    public RecieptType TotalPaid { get; set; }
    private DateTime _date;
    public DateTime Date { get => _date;
    set
        {
            if(value == DateTime.Now)
            {
                throw new RecieptException("Ошибка с датой!");
            }
            else
            {
                _date = value;   
            }
        }
    
    }






    public Receipt(string title, decimal totalAmount)
    {
        ID = idCounter++;
        Title = title;
        TotalAmount = totalAmount;
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Total Amount: {TotalAmount}");
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    // Общий метод
    public void ClassDetection()
    {
        Console.WriteLine("Type of Reciept:" + base.ToString());
    }





    public override string ToString()
    {
        return $"Type: {base.GetType()} Title of Reciept: {Title} , Number: {ID} , Total: {TotalAmount}";
    }


}


public class Invoice : Document, IContainsDate
{
    public List<Product> Products { get; set; }
    public DateTime Date { get; set; }

    public Invoice(string title, int number)
    {
        Title = title;
        Number = number;
        Products = new List<Product>();
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine("Products:");
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name} - {product.Quantity} count");
        }
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    public override string ToString()
    {
        return $"Type: {base.GetType()} Title: {Title} , Num: {Number} , Products: {Products.Count}";
    }

 
}




public class Product
{
    public string Name { get; set; }

    private int _quan;
    public int Quantity { get => _quan; 
    set
        {
            if(value > 10)
            {
                throw new QuanException("Не правильное колличество:" , value);
            }
            else
            {
                _quan = value;
            }
        }
    }

    private decimal _cost;
    public decimal Cost
    {
        get => _cost;
        set
        {
            if (value < 0)
            {
                throw new ProductException("Цена не может быть меньше 0",value);
            }
            else
            {
                _cost = value;
            }
            }

    }

    public Product(string name, int quantity, decimal cost)
    {
        Name = name;
        Quantity = quantity;
        Cost = cost;
    }

    public string ToString()
    {
        return $"Type:{base.GetType()}  ItemName: {Name} , Amount: {Quantity}";
    }


 
}




class Programm
{
    static void Main()
    {

        try
        {
            // Assert

            Organization testOrg = null;
            
            //Debug.Assert(testOrg != null, "Ошибка ассерта");
            


            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();

            //}
            //Debugger.Break();

            // Debug and Debugger

            Debug.WriteLine("*********ДЕБАГ***********");


            // 1,2
            Invoice inv = new Invoice("#1", 001);
            inv.Products.Add(new Product("Arbuz", 10, 1));




            Console.WriteLine("------------------------------");
            inv.Products.Add(new Product("Banan", 10, -2));
            inv.ShowInformation();
            Console.WriteLine("------------------------------");
            inv.ClassDetection();
            Console.WriteLine("------------------------------");

            Console.WriteLine("------------------------------");

            Console.WriteLine(inv.ToString());

            Console.WriteLine("------------------------------");


            //3
            Receipt rec = new Receipt("Receipt 001", 100.50m)
            {
                TotalPaid = RecieptType.Paid

            };
            NewDate date = new NewDate();
            date.SetDate(DateTime.MinValue);
            rec.SetDate(DateTime.Now.Date);

            Console.WriteLine("------------------------------");





            List<object> documents = new List<object> { rec };


            foreach (var item in documents)
            {
                if (item is Document)
                {
                    Document document = item as Document;
                    document.ClassDetection();
                    document.ShowInformation();
                    document.ToString();
                    Console.WriteLine("------------------------------");
                }
                if (item is IContainsDate)
                {
                    IContainsDate dateTime = item as IContainsDate;
                    dateTime.SetDate(DateTime.Now);
                    dateTime.ClassDetection();
                    Console.WriteLine(dateTime.Date.ToShortDateString());
                }
            }



            //4


            object[] objects = { rec, inv, date };

            Organization org = new Organization("BSTU")
            {

                Place = new Address
                {
                    Country = "Belarus",
                    City = "Minsk",
                },
            };

            //objects[3] = org;






            Printer printer = new Printer();

            foreach (var obj in objects)
            {
                printer.IAmPrinting(obj);
                Console.WriteLine("------------------------------");

            }



            //5

            //Organization org2 = null;
            //Console.WriteLine("Organization: " + org2.OrgName);

            Accounting act = new Accounting();
            Console.WriteLine("Accounting");

            act.AddData(inv);


            act.DisplayData();
            act.AddData(rec);
            act.DisplayData();

            Controller control = new Controller(act);


            Console.WriteLine($"Total Cost of Arbuz: {control.GetTotalCostOfProduct("Arbuz")}");
            Console.WriteLine($"Number of reciepts: {control.GetNumberOfReceipts()}");


            DateTime endDate = DateTime.Now;
            Console.WriteLine(control.GetDocumentByDate(endDate));



         

        }
        catch (ProductException ex1)
        {
            Console.WriteLine("ProductException caught:" + ex1);

            Console.WriteLine("Value:" + ex1.Cvalue);
        }
        catch (QuanException ex2)
        {
            Console.WriteLine("QuanException caught:" + ex2);
            Console.WriteLine("Value: " + ex2.Value);
            throw;
        }
        catch (RecieptException ex)
        {
            Console.WriteLine("RecieptException caught:" + ex);
        }
        catch (IndexOutOfRangeException ex3)
        {
            Console.WriteLine("IndexOutOfRangeException caught:" + ex3);

        }
        catch (NullReferenceException ex4)
        {
            Console.WriteLine("NullReferenceException caught:" + ex4);
        }
        catch (DivideByZeroException ex5)
        {
            Console.WriteLine("DivideByZeroException caught:"+ ex5);
        }
        finally
        {
            Console.WriteLine("No errors!");
        }









    }
}

