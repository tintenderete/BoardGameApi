using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Game
    {
        private Player[] players;
        private int currentPlayer;
        private Board board;
        private TurnManager turnManager;

        public Game(Board board, TurnManager turnManager )
        {
           
        }

    }
}
