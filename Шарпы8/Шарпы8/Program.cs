

using System.Runtime.CompilerServices;
namespace vocem;
public class Programmer
{
    public delegate void HandleRemove();
    public event HandleRemove ERemove;
    public delegate void Mutate();
    public event Mutate EMutate;
  

    private string v;
    private List<string> langs;

    public Programmer(string v, List<string> langs)
    {
        this.v = v;
        this.langs = langs;
    }


    public void Display()
    {
        ERemove.Invoke();
        EMutate.Invoke();
    }


    public void PrintMe()
    {
        Console.WriteLine($"Name: {v}  List: {langs.Count} ");
    }

    public void PrintList()
    {
        foreach(var i in langs)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }




}



class Programm
{

   

    static void Main()
    {

        List<string> langs = new List<string> {"Python","JavaScript","C#"};

        Programmer pr1 = new Programmer("Vlad",langs);

        pr1.PrintMe();
        pr1.PrintList();
        
        pr1.ERemove += () => {

            int n;
            Console.WriteLine($"Выберите удаление 1 или 2");
            n = int.Parse(Console.ReadLine());

            try
            {
                if (n == 1)
                    langs.RemoveAt(0);
                else if (n == 2)
                    langs.RemoveAt(langs.Count - 1);

            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { }
        };

        pr1.EMutate += () =>
        {
            int n1 = new Random().Next(0,langs.Count);
            int n2 = new Random().Next(0,langs.Count);
            string buff = langs[n2];
            langs[n2] = langs[n1];
            langs[n1] = buff;
            foreach(var i in langs)
            {
                Console.Write(i + "  \n");
            }

        };
        pr1.Display();


        string str1;
        string myName = "Лемешевский Владислав Олегович";
        Action<string> Input = (str) => Console.WriteLine(str); 
        Action<string> Print = (str) => { Console.WriteLine($"Результат: {str}"); };
        Func<string, string> RemoveSpaces = (str) => { return str.Replace(" " , ""); };
        Predicate<string> CompareNames = (str) => { return myName.Equals(str); };
        Func<string, string>[] allFuncs = {  RemoveSpaces  };


      StringRedone(myName, allFuncs, CompareNames , Input,  Print);



    }

    static (string, bool) StringRedone(
           string str,
           Func<string, string>[] functions,
           Predicate<string> predicate,
           Action<string> action,
           Action<string> start

       )
    {
        action(str);
        foreach (Func<string, string> func in functions)
        {
            str = func(str);
        }
        start(str);
      
        return (str, predicate(str));
    }


}

