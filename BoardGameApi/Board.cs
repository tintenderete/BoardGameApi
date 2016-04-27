using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Board
    {
        protected Cell[,] board = new Cell[1,1];

        public Board()
        {

        }

        public Board(Cell[,] board)
        {
            this.board = board;
        }

        public Cell[,] GetBoard()
        {
            return board;
        }

        public Cell GetCell(int boardPosA, int boardPosB)
        {
            Cell cellToReturn;

            cellToReturn = board[boardPosA, boardPosB];

            return cellToReturn;   
        }

        public Cell GetCell(Piece piece)
        {
            int pieceId = piece.GetId();
            int pieceId_i;
            foreach (Cell cell in board)
            {
                pieceId_i = cell.GetPiece().GetId();
                if (pieceId == pieceId_i)
                {
                    return cell;
                }
            }
           
            return new Cell();
        }

        public Piece GetPiece(int boardPosA, int boardPosB)
        {
            Piece pieceToreturn;
            Cell cellContainer;

            cellContainer = GetCell(boardPosA, boardPosB);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public Piece GetPiece(Cell cell)
        {
            Piece pieceToreturn;
            int[] cellBoardPos;
            Cell cellContainer;

            cellBoardPos = cell.GetBoardPosition();

            cellContainer = GetCell(cellBoardPos[0], cellBoardPos[1]);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public void MovePiece(Cell origin, Cell destiny)
        {
            destiny.SetPiece(origin.GetPiece());
            origin.SetEmptyCell();
        }

    }
}
