using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Cell: Actor
    {

        protected int[] boardPosition;
        protected Piece currentPiece;

        public Cell()
        {

        }

        public Cell(int[] boardPosition, Piece piece)
        {
            this.boardPosition = boardPosition;
            this.currentPiece = piece;
        }

        public int[] GetBoardPosition()
        {
            return boardPosition;
        }

        public Piece GetPiece()
        {
            return currentPiece;
        }

        public void SetPiece(Piece newPiece)
        {
            this.currentPiece = newPiece;
        }

        public void SetEmptyCell()
        {
            this.currentPiece = new NoPiece();
        }
    }
}
