// Квитанция, Накладная, Документ, Чек, Дата, Организация.

namespace шарпы13
{
    public abstract class Document
    {
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
    [Serializable]
    public class Organization
    {
        public string OrgName { get; set; }
        public string Address { get; set; }


        public string ToString()
        {
            return $"Type: {base.GetType()} OrgName: {OrgName} , Adress: {Address}";
        }

    }


    public sealed class Product : Document, IContainsDate
    {

        private int ID { get; set; }

        public int rID
        {
            get { return ID; }
        }

        int idCounter = 1;

        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public Product(string title, decimal totalAmount)
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



        public string ToString()
        {
            return $"Type: {base.GetType()} Title of Reciept: {Title} , Number: {ID} , Total: {TotalAmount}";
        }


    }

    [Serializable]

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



        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public string ToString()
        {
            return $"Type: {base.GetType()} Title: {Title} , Num: {Number} , Products: {Products.Count}";
        }

    }



    public class Printer
    {

        public void IAmPrinting(object obj)
        {
            Console.WriteLine($"OBJ type: {obj.GetType()}");

            if (obj is Document)
            {
                Document document = obj as Document;
                Console.WriteLine(document.ToString());
            }
            if (obj is IContainsDate)
            {
                IContainsDate containsDate = obj as IContainsDate;
                Console.WriteLine(containsDate.ToString());
            }
            if (obj is Organization)
            {
                Organization org = obj as Organization;
                Console.WriteLine(org.ToString());
            }



        }
    }

}
    //class Programm
    //{
    //    static void Main()
    //    {

    //        Console.WriteLine("------------------------------");
    //        Receipt receipt = new Receipt("Receipt 001", 100.50m);
    //        receipt.ShowInformation();
    //        Console.WriteLine("------------------------------");
    //        Invoice invoice = new Invoice("Invoice 001", 001);
    //        invoice.Products.Add(new Product("Arbuz", 20, 30));
    //        invoice.Products.Add(new Product("Banana", 15, 5));
    //        invoice.SetDate(DateTime.Now);
    //        invoice.ShowInformation();
    //        Console.WriteLine("------------------------------");
    //        invoice.ClassDetection();
    //        Console.WriteLine("------------------------------");

    //        NewDate date = new NewDate();
    //        date.SetDate(DateTime.Now);

    //        Organization org = new Organization("BSTU", "Minsk");





    //        Console.WriteLine("Date: " + date.Date.ToShortDateString());
    //        Console.WriteLine("Organization: " + org.OrgName + ", Address: " + org.Address);
    //        Console.WriteLine("------------------------------");


    //        List<object> documents = new List<object> { receipt };


    //        foreach (var item in documents)
    //        {
    //            if (item is Document)
    //            {
    //                Document document = item as Document;
    //                document.ClassDetection();
    //                document.ShowInformation();
    //                document.ToString();
    //                Console.WriteLine("------------------------------");
    //            }
    //            if (item is IContainsDate)
    //            {
    //                IContainsDate dateTime = item as IContainsDate;
    //                dateTime.SetDate(DateTime.Now);
    //                dateTime.ClassDetection();
    //                Console.WriteLine(dateTime.Date.ToShortDateString());
    //            }
    //        }

    //        Console.WriteLine("------------------------------");

    //        Console.WriteLine(invoice.ToString());

    //        Console.WriteLine("------------------------------");

    //        object[] objects = { receipt, invoice, date, org };
    //        Printer printer = new Printer();

    //        foreach (var obj in objects)
    //        {
    //            printer.IAmPrinting(obj);
    //            Console.WriteLine("------------------------------");

    //        }

    //    }
    //}

