
public class MyList<T>
{
    public List<T> items = new List<T>();
    public MyList(List<T> items)
    {
        this.items = items;
    } 


    public static MyList<T> operator +(T newValue , MyList<T> a)
    {

        a.items.Insert(0, newValue);
        return  a;

    }

    public static MyList<T> operator --(MyList<T> a)
    {
        a.items.RemoveAt(0);
        return a;
    }

    public static bool operator ==(MyList<T> a, MyList<T> b)
    {
        return a.items.Equals(b.items);
    }

    public static bool operator !=(MyList<T> a , MyList<T> b)
    {
        return !(a.items.Equals(b.items));
    }

    public static MyList<T> operator *(MyList<T> a, MyList<T> b)
    {
        List<T> combinedItems = new List<T>(a.items);
        combinedItems.AddRange(b.items);
        return new MyList<T>(combinedItems);
    }   

    public void Print()
    {
        foreach(var i in items)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public class Production
    {
        public static int idCounter = 1;
        public int ID { get; set; } 
        public string Name { get; set; }

        public Production(string name)
        {
            ID = idCounter++;
            Name = name;
        }


       public void PrintProd()
        {
           
            Console.WriteLine($"Org ID: {ID} Name: {Name}");
        }

    }

    public class Developer
    {
        public int ID { get; set; }
        public string FullName { get; set; }
                
        public string Otdel { get; set; }

        public static int idCounter2 = 0;

        public Developer(string fullName, string otdel)
        {
            ID = idCounter2++;
            FullName = fullName;
            Otdel = otdel;
        }

        public void PrintDev()
        {

            Console.WriteLine($"Dev ID: {ID} Name: {FullName} Otdel: {Otdel}");
        }

    }


   


}


public static class StatisticOperation
{



    public static int Sum<T>(MyList<T> a)
    {
        int sum = 0;
        foreach (T item in a.items)
        {
            if (item is int intValue)
            {
                sum += intValue;
            }
            else
            {
                Console.WriteLine($"ошибка");
            }
        }

        return sum;

    }

    public static int Difference<T>(MyList<T> a)
    {

        if (a.items[0] is int min && a.items[1] is int max)
        {
            foreach (T item in a.items)
            {
                if (item is int intValue)
                {
                    if (intValue < min)
                    {
                        min = intValue;
                    }
                    if (intValue > max)
                    {
                        max = intValue;
                    }
                }
            }
            return max - min;
        }
        else
        {
            return 0;
        }

    }


    public static int Counter<T>(MyList<T> a)
    {
        return a.items.Count;
    }



    // DOPS


    public static int WordsCounter(this string str)
    {
        int count = 0;
        string[] words = str.Split(new char[] { ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word) && char.IsUpper(word[0]))
            {
                count++;
            }
        }
        return count;
    }

    public static int ItemRepeater<T>(this MyList<T> a)
    {
        return a.items.Count() - a.items.Distinct().Count();
    }

}

//public static class StringExtensions
//{
 
//}

class Program
{

    static void Main()
    {
        string g = "Lemiasheusky";

        MyList<string> newList = new MyList<string>(new List<string> {"Vladisalv" , "Olegovich" });
        MyList<string> newList2 = g + newList;    
        MyList<string> test = new MyList<string>(new List<string> { "Test"});

        Console.WriteLine(test != newList2);


        MyList<string> myList4 = test * newList2;
        myList4.Print();
      
         
        // 2
        MyList<string>.Production prod = new MyList<string>.Production("BSTU");
        prod.PrintProd();


         // 3
        MyList<string>.Developer dev = new MyList<string>.Developer("Лемешевский Владислав", "BSTU");
        dev.PrintDev();


        // 4

        MyList<int> intList = new MyList<int>(new List<int> { 1, 2, 3 });

         int sum = StatisticOperation.Sum(intList);
        int dif = StatisticOperation.Difference(intList);
        int cou = StatisticOperation.Counter(intList);
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Dif: {dif}");
        Console.WriteLine($"Count: {cou}");


        // dops 
        string str = string.Join(" ", myList4.items);
        int wordsCount = str.WordsCounter();
        Console.WriteLine($"Words with big A: {wordsCount}");

        MyList<int> duplInt = new MyList<int>(new List<int> {1,2,3,4,2,3});
        int hasDupl = duplInt.ItemRepeater();
        Console.WriteLine($"Duplicates?: {hasDupl}");

    }
}