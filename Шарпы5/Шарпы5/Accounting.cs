using System;
using System.Collections.Generic;
using System.Linq;

namespace accounting
{
    public class Controller
    {
        private Accounting accounting;

        public Controller(Accounting accounting)
        {
            this.accounting = accounting;
        }

        public decimal GetTotalCostOfProduct(string productName)
        {
            decimal totalCost = 0;

            foreach (var document in accounting.Documents)
            {
                if (document is Invoice invoice)
                {
                    totalCost += invoice.Products
                        .Where(product => product.Name == productName)
                        .Sum(product => product.Cost );
                }
            }

            return totalCost;
        }

        public int GetNumberOfReceipts()
        {
            return accounting.Documents.Count(document => document is Receipt);
        }

        public string GetDocumentByDate(DateTime date)
        {
            return accounting.Documents
       .Where(document => document is IContainsDate dateDocument &&
                         dateDocument.Date >= date)
       .ToString();
        }

    }
}

public class Accounting
{
    public List<Document> Documents
    {
        get; private set;
    }

    public Accounting()
    {
        Documents = new List<Document>();
    }

    public void AddData(Document document)
    {
        Documents.Add(document);
    }

    public void RemoveData(Document document)
    {
        Documents.Remove(document);
    }

    public void DisplayData()
    {
        foreach (var document in Documents)
        {
            document.ShowInformation();
            Console.WriteLine("------------------------------");
        }
    }
}



