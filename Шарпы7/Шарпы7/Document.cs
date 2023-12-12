using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab07
{
    partial class Document
    {
        public string Title { get; set; }
        public int Number { get; set; }


        public Document(string title, int number)
        {
            Title = title;
            Number = number;
        }

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
}
