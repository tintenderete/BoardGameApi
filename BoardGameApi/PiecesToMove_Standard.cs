using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PiecesToMove_Standard
    {
        private Board board;
        private Player currentPlayer;

        public List<Action> movements;

        public PiecesToMove_Standard(Board board, Player currentPlayer)
        {
            this.board = board;
            movements = new List<Action>();
            this.currentPlayer = currentPlayer;
        }


        private void BasicMovementsAvailable()
        {
            movements.Clear();

            Cell[,] boardTable = this.board.GetBoard();
            Piece pieceAux;

            Action newMove;

            foreach (Cell cell in boardTable)
            {
                pieceAux = cell.GetPiece();

                if (board.IsPlayerPiece(cell, currentPlayer ))
                {
                    newMove = new Action(cell, board.CellsInRange(cell, cell.GetPiece().GetBasicMovement()));
                    newMove.NoPlayerCellsInDestiny(currentPlayer);
                    movements.Add(newMove);
                }

            }
        }

       


    }
}
