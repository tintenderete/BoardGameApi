using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PiecesToMove_test
    {
        Board board;
        PiecesToMove piecesToMove;
        Player player_W;
        Player player_B;

        public PiecesToMove_test()
        {
            BoardGameFactory factory = new BoardGameFactory();

            board = factory.MakeBoard((int)BoardGameFactory.names.Standard);

            player_W = new Player((int)Player.colors.White);
            player_B = new Player((int)Player.colors.Black);
        }
    }
}
