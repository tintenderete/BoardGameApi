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
            piecesToMove.BasicMovementsAvailable();
        }

        public bool IsMovementsCorrect()
        {
            if (!IsMovementLengthCorrect())
            {
                return false;
            }

            return true;
            
        }

        private bool IsMovementLengthCorrect()
        {
            if (piecesToMove.movements.Count != 3)
            {
                Console.WriteLine("Length incorrect, now is: " + piecesToMove.movements.Count);
                return false;
            }
            return true;
        }


    }
}
