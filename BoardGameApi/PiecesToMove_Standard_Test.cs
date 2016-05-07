using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PiecesToMove_Standard_Test
    {
        Board board;
        Player playerW;
        Player playerB;
        PiecesToMove_Standard piecesToMove;

        public PiecesToMove_Standard_Test()
        {
            board = new StandardBoardGame();
            playerW = new Player((int)Player.colors.White);
            piecesToMove = new PiecesToMove_Standard(board, playerW);

            
        }
    }
}
