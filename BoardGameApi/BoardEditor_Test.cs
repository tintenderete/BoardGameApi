using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class BoardEditor_Test
    {
        BoardTableEditor editor;
        Board board;
        public BoardEditor_Test()
        {
            editor = new BoardTableEditor(3, 3);

            editor.SetPointerInLine(0);

            editor.PushPiece(3, (int)Piece.colors.NoPiece);

            editor.SetPointerInLine(1);

            editor.PushPiece(1, (int)Piece.colors.NoPiece);
            editor.PushPiece(2, (int)Piece.colors.White);

            editor.SetPointerInLine(2);

            editor.PushPiece(1, (int)Piece.colors.White);
            editor.PushPiece(1, (int)Piece.colors.NoPiece);
            editor.PushPiece(1, (int)Piece.colors.White);

            board = editor.GetBoard();
        }

        public bool ArePiecesInCorrectCell()
        {
            int[] line2 = new int[3] { (int)Piece.colors.White, (int)Piece.colors.NoPiece, (int)Piece.colors.White };
            int[] line1 = new int[3] { (int)Piece.colors.NoPiece, (int)Piece.colors.White, (int)Piece.colors.White };
            int[] line0 = new int[3] { (int)Piece.colors.NoPiece, (int)Piece.colors.NoPiece, (int)Piece.colors.NoPiece };

            if (!CheckLine(line2, 2) ||
                !CheckLine(line1, 1) ||
                !CheckLine(line0, 0))
            {
                return false;
            }

            return true;
        }

        private bool CheckLine(int[] line, int lineNumber)
        {
            Cell[,] boardTable = board.GetBoard();
            int horizontalSize = board.GetSize().vertical;
            int pieceColor;

            for (int i = 0; i < horizontalSize; i++)
            {
                pieceColor = boardTable[i, 2].GetPiece().GetColor();

                if (pieceColor != line[i])
                {
                    Console.Write("Piece in line"+ lineNumber + ", and position: " + i + "is no correct");
                    return false;
                }
                
            }

            return true;

        }


    }
}
