using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printer
{
   partial class Printer
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
