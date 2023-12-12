using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы9
{
    internal class GameCollection 
    {
       private readonly BlockingCollection<Game> _games = new BlockingCollection<Game>();


        public void AddGame(Game game)
        {
           
            try
            {
                _games.Add(game);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveGame()
        {
            try
            {
                _games.TryTake(out _);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Game> GetGames()
        {
            return _games.ToList();

        }

    }
}
