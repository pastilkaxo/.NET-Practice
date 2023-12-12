using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products;
internal partial class Product
{
    private static int totalObjects = 0;
    private readonly int ID;
    public const string Category = "Fruits";
    private static int idCounter = 1;

}