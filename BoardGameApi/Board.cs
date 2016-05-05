using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Board
    {
        protected Cell[,] boardTable = new Cell[1,1];
        protected Position size = new Position(1,1);

        public Board()
        {

        }

        public Board(Cell[,] board, int HorizontalSize, int VerticalSize)
        {
            this.boardTable = board;
            size.horizontal = HorizontalSize;
            size.vertical = VerticalSize;
        }

        public Cell[,] GetBoard()
        {
            return boardTable;
        }

        public Cell GetCell(int boardPosV, int boardPosH)
        {
            Cell cellToReturn;

            cellToReturn = boardTable[boardPosV, boardPosH];

            return cellToReturn;   
        }

        public Cell GetCell(Piece piece)
        {
            int pieceId = piece.GetId();
            int pieceId_i;
            foreach (Cell cell in boardTable)
            {
                pieceId_i = cell.GetPiece().GetId();
                if (pieceId == pieceId_i)
                {
                    return cell;
                }
            }
           
            return new Cell();
        }

        public Piece GetPiece(int boardPosV, int boardPosH)
        {
            Piece pieceToreturn;
            Cell cellContainer;

            cellContainer = GetCell(boardPosV, boardPosH);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public Piece GetPiece(Cell cell)
        {
            Piece pieceToreturn;
            Position cellBoardPos;
            Cell cellContainer;

            cellBoardPos = cell.GetBoardPosition();

            cellContainer = GetCell(cellBoardPos.vertical, cellBoardPos.horizontal);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public void MovePiece(Cell origin, Cell destiny)
        {
            destiny.SetPiece(origin.GetPiece());
            origin.SetEmptyCell();
        }

        public Position GetSize()
        {
            return size;
        }

    }
}
