using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы9
{
    internal class Game 
    {

        public  string _name { get; }
        public string _version { get; }
        public string _description { get; }
        public GamePlayers _players { get; }





        public Game(string name, string version, string desc , IEnumerable<string> players)
        {
            _name = name;
            _version = version;
            _description = desc;
            _players = new GamePlayers(players);
            
        }

        public override string ToString()
        {
            return $"Game: {_name} ver: {_version} desc: {_description}  with players: {string.Join(",",_players)}";
        }

        public void AddPlayer(string player)
        {
            _players.Add(player);
        }

        public bool RemovePlayer(string player)
        {
            return _players.Remove(player);
        }

        public void ClearPlayers()
        {
            _players.Clear();
        }

        public bool ContainsPlayer(string player)
        {
            return _players.Contain(player);
        }


    }

}
