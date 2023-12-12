// Квитанция, Накладная, Документ, Чек, Дата, Организация.

using printer;
using accounting;

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
    public  Address Place{ get; set; }
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
    public DateTime Date { get; set; }

    public Receipt(string title, decimal totalAmount )
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
    public int Quantity { get; set; }
    public decimal Cost { get; set; }

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

        Console.WriteLine("------------------------------");
        Receipt receipt = new Receipt("Receipt 001", 100.50m)
        {
            TotalPaid = RecieptType.Paid

        };
        receipt.ShowInformation();
        Console.WriteLine("------------------------------");
        Invoice invoice = new Invoice("Invoice 001", 001);
        invoice.Products.Add(new Product("Arbuz", 20, 2));
        invoice.Products.Add(new Product("Banana", 15, 5));
        invoice.SetDate(DateTime.Now);
        invoice.ShowInformation();
        Console.WriteLine("------------------------------");
        invoice.ClassDetection();
        Console.WriteLine("------------------------------");

        NewDate date = new NewDate();
        date.SetDate(DateTime.Now);

        Organization org = new Organization("BSTU")
        {

             Place = new Address
            {
                Country = "Belarus",
                City = "Minsk",
            },
        };





        Console.WriteLine("Date: " + date.Date.ToShortDateString());
        Console.WriteLine("Organization: " + org.OrgName + ", Address: " + org.Place.Country + " " + org.Place.City);
        Console.WriteLine("------------------------------");


        List<object> documents = new List<object> { receipt };


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

        Console.WriteLine("------------------------------");

        Console.WriteLine(invoice.ToString());

        Console.WriteLine("------------------------------");

        object[] objects = { receipt, invoice, date, org };
        Printer printer = new Printer();

        foreach (var obj in objects)
        {
            printer.IAmPrinting(obj);
            Console.WriteLine("------------------------------");

        }


        Accounting act = new Accounting();
        Console.WriteLine("Accounting");

        act.AddData(invoice);


        act.DisplayData();
        act.AddData(receipt);
        act.DisplayData();

        Controller control = new Controller(act);


        Console.WriteLine($"Total Cost of Arbuz: {control.GetTotalCostOfProduct("Arbuz")}");
        Console.WriteLine($"Number of reciepts: {control.GetNumberOfReceipts()}");


        DateTime endDate = DateTime.Now;
        Console.WriteLine(control.GetDocumentByDate(endDate));




    }
}

