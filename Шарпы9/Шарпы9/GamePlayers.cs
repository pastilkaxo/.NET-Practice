using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы9
{
    internal class GamePlayers : IEnumerable<string>
    {
        private List<string> _players;

        public GamePlayers(IEnumerable<string> players)
        {
            _players = new List<string>(players);
        }

        public List<string> Players { get => _players; }
        public int Count { get => _players.Count; }


        public void Add(string player)
        {
            if (_players.Contains(player))
            {
                return;
            }
            try
            {
                _players.Add(player);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        public bool Remove(string player)
        {
            return _players.Remove(player); 
        }

        public void Clear()
        {
            try
            {
                _players.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }

        public bool Contain(string player)
        {
            return _players.Contains(player);
        }



        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)_players).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_players).GetEnumerator();
        }
    }


    

}
