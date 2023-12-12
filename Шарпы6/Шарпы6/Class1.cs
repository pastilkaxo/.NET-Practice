using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    partial class ProductException : Exception 
    {
        public decimal Cvalue { get; }
        public ProductException(string msg , decimal cvalue) : base(msg) {
        Cvalue = cvalue;
        }

    }


    partial class QuanException : ArgumentException
    {
        public int Value { get; }
        public QuanException(string msg , int value ) : base(msg)
        {
            Value = value;
        }
    }

    partial class RecieptException : InvalidOperationException
    {
        public RecieptException(string msg) : base(msg) { } 
    }


  




}
