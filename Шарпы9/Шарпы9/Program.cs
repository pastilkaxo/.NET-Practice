using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Шарпы9;

class Programm
{
    static void Main()
    {

        // task 1

        GameCollection gameCollection = new GameCollection();
        Game game1 = new Game("Mario", "0.01", "Jumper", new List<string> { "Vlad", "Nikita" });
        Game game2 = new Game("Cyberpunk 2077", "2.02", "RPG Shooter", new List<string> { "Vlad", "Nikita", "Leha" });
        Game game3 = new Game("Valorant", "7.3", "Shooter", new List<string> { "Vlad" });

        game1.AddPlayer("Artem");
       bool cntP =  game1.ContainsPlayer("A");
        Console.WriteLine(cntP);
        game1.RemovePlayer("Nikita");

        gameCollection.AddGame(game1);
        gameCollection.AddGame(game2);
        gameCollection.AddGame(game3);

        gameCollection.RemoveGame();

        foreach (var game in gameCollection.GetGames())
        {
            Console.WriteLine(game);
        }




        // task 2

        BlockingCollection<int> ints = new BlockingCollection<int>();

        for(int i = 0; i < 10; i++)
        {
            ints.Add(i);
        }


       

        int n = 3;
        for(int j = 0; j < n; j++)
        {
            ints.TryTake(out _);
        }

        ints.Add(100);

        Console.WriteLine("Первая коллекция:");
        foreach (var el in ints)
        {
            Console.Write(el + " ");
        }

        
        LinkedList<int> ll = new LinkedList<int>(ints);

        Console.WriteLine("\nВторая коллекция:");
        foreach (var item in ll)
        {
            Console.Write(item);
        }
        Console.WriteLine();

        int valueToFind = 100;
        var node = ll.Find(valueToFind);
        if (node != null)
        {
            Console.WriteLine($"Значение {valueToFind} найдено во второй коллекции.");
        }
        else
        {
            Console.WriteLine($"Значение {valueToFind} не найдено во второй коллекции.");
        }


        // task 3 


        ObservableCollection<Game> obs = new ObservableCollection<Game>();


        obs.CollectionChanged += Obs_CollectionChanged;

        obs.Add(game1);
        obs.Add(game2);
        obs.Add(game3);

        obs.Remove(game2);

        


    }

    private static void Obs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems?[0] is Game game)
                {
                    Console.WriteLine($"Добавлен новый объект: {game._name}");
                }
                break;
            case NotifyCollectionChangedAction.Remove: 
                if (e.OldItems?[0] is Game game3)
                    Console.WriteLine($"Удален объект: {game3._name}");
                break;
            case NotifyCollectionChangedAction.Replace: 
                if ((e.NewItems?[0] is Game game1) &&
                    (e.OldItems?[0] is Game game2))
                    Console.WriteLine($"Объект {game2._name} заменен объектом {game1._name}");
                break;
        }

    }
}