
using System.Text.Json;



namespace lab07;
internal interface IGenericInter<T>
{

    void Add(T obj);
    void Remove(T obj);
    void Display();
    T Find(Predicate<T> predicate);
}

  internal partial class CollectionType<T> : IGenericInter<T> where T : class
{
    public List<T> items = new List<T>();

    public CollectionType(List<T> items)
    {
        this.items = items;
    }

   

    public void  Add(T item)
    {
        try
        {
            items.Add(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding: " + ex.Message);
        }
        finally
        {
        }
    }
    public void Remove(T item)
    {
       
        try
        {
            items.Remove(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while removing: " + ex.Message);
        }
        finally
        {
        }

    }
    public void Display()
    {
        foreach (var item in items)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public T Find(Predicate<T> predicate)
    {
        return items.Find(predicate);
    }



    public string JSONString()
    {
        return JsonSerializer.Serialize(items);
    }

    public void ToJS(string filename)
    {
        string serCol = JSONString();
        try
        {
            File.WriteAllText(filename, serCol);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while converting to JSON: " + ex.Message);
        }
    }



    public static CollectionType<T> FromJSString<T>(string jsonString) where T : class
    {
        List<T>? desColl = JsonSerializer.Deserialize<List<T>>(jsonString);

        return new CollectionType<T>(desColl);
    }

    public static CollectionType<T> FromJS<T>(string filename) where T : class
    {
        string serCol = File.ReadAllText(filename);

        return FromJSString<T>(serCol);
    }






}
  
class Programm
{
    static void Main()
    {

        // 3:
        //var intCollection = new CollectionType<int>(new List<int> { 1, 2, 3, 4, 5 });
        //intCollection.Add(6);
        //intCollection.Remove(3);
        //intCollection.Display();

        //var doubleCollection = new CollectionType<double>(new List<double> { 1.1, 2.2, 3.3 });
        //doubleCollection.Add(4.4);
        //doubleCollection.Remove(2.2);
        //doubleCollection.Display();

        var stringCollection = new CollectionType<string>(new List<string> { "apple", "banana", "cherry" });
        stringCollection.Add("date");
        stringCollection.Remove("banana");
        stringCollection.Display();

        //int itemToFind = intCollection.Find(item => item == 4);
        //Console.WriteLine("Found: " + itemToFind);

        //double doubleToFind = doubleCollection.Find(item => item == 1.1);
        //Console.WriteLine("Found: " + doubleToFind);

        string stringToFind = stringCollection.Find(item => item == "date");
        Console.WriteLine("Found: " + stringToFind);


        // 4:


        var docCollection = new CollectionType<Document>(new List<Document> { new Document("#001", 100) });
        docCollection.Add(new Document("#002", 20));
        docCollection.Display();



        // 5:



        string serializationFilename = @"C:\Users\Влад\source\repos\Шарпы7\Шарпы7\collect.json";
        stringCollection.ToJS(serializationFilename);

        CollectionType<string> newCollect = CollectionType<string>.FromJS<string>(serializationFilename);
        newCollect.Display();
    }




}