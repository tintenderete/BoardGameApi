using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class BoardTableEditor
    {
        Board board;
        int pointer;
        PieceFactory pieceFactory = new PieceFactory();

        public BoardTableEditor()
        {
            board = new Board(); 
        }

        public BoardTableEditor(int HorizontalSize, int VerticalSize)
        {
            NewBoard(HorizontalSize, VerticalSize);
        }

        public void NewBoard(int HorizontalSize, int VerticalSize)
        {
            Cell[,] boardTable = new Cell[HorizontalSize, VerticalSize];
            board = new Board(boardTable, HorizontalSize, VerticalSize);
            PushAllNoPieces(board);
        }

        public Board GetBoard()
        {
            return board;
        }

        public void SetPointerInLine(int line)
        {
            pointer = line;
        }

        public void PushPiece(int numOfPieces, int piece)
        {
            int initPos = FirstEmptyCell();
            Cell[,] board;

            for (int i = 0; i < numOfPieces; i++)
            {
                board =  this.board.GetBoard();
                board[initPos + i, pointer].SetPiece(pieceFactory.MakePiece(piece));
            }
        }

        private int FirstEmptyCell()
        {
            Cell[,] board = this.board.GetBoard();
            int verticalSize = this.board.GetSize().horizontal;
            int posFirstCellEmpty = 0;

            for (int i = 0; i < verticalSize ; i++)
            {
                int color = board[i, pointer].GetPiece().GetColor();
                if (IsCellEmpty(color))
                {
                    posFirstCellEmpty = i;
                    return posFirstCellEmpty;
                }
            }

            return posFirstCellEmpty;
        }

        private bool IsCellEmpty(int color)
        {
            if (color == (int)Piece.colors.NoPiece)
            {
                return true;
            }
            return false;
        }

        private void PushAllNoPieces(Board board)
        {
            Cell[,] boardTable = board.GetBoard();
            
            foreach (Cell cell in boardTable)
            {
                cell.SetPiece(pieceFactory.MakePiece((int)PieceFactory.names.NoPiece));
            }
        }


    }
}
