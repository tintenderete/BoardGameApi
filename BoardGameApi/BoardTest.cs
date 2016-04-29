using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class BoardTest
    {
        Piece piece;
        Piece noPiece;
        Cell cellA;
        Cell cellB;

        Cell[,] boardSample;
        Board board;

        public BoardTest()
        {
            piece = new Piece((int)Piece.colors.White, new List<Position>());
            noPiece = new Piece((int)Piece.colors.NoPiece, new List<Position>());
            cellA = new Cell(new Position(0, 0), piece);
            cellB = new Cell(new Position(0, 1), noPiece);

            boardSample = new Cell[2, 1];
            boardSample[0, 0] = cellA;
            boardSample[1, 0] = cellB;

            board = new Board(boardSample);
             
        }

        public bool GetBoard_Test()
        {
            if (board.GetBoard() != boardSample)
            {
                Console.WriteLine("boardtable incorrect");
                return false;
            }

            return true;
        }

        public bool GetCellByPosition_test()
        {
            if (board.GetCell(0, 0) != cellA)
            {
                Console.WriteLine("cell A incorrect");
                return false;
            }
            if (board.GetCell(1, 0) != cellB)
            {
                Console.WriteLine("cell B incorrect");
                return false;
            }
            return true;
        }

        public bool GetCellByPiece_test()
        {
            if (board.GetCell(piece) != cellA)
            {
                Console.WriteLine("cell A incorrect");
                return false;
            }
            if (board.GetCell(noPiece) != cellB)
            {
                Console.WriteLine("cell B incorrect");
                return false;
            }
            return true;
        }

        public bool GetPieceByPosition_test()
        {
            if (board.GetPiece(0,0) != piece)
            {
                Console.WriteLine("piece incorrect");
                return false;
            }
            if (board.GetPiece(1, 0) != noPiece)
            {
                Console.WriteLine("noPiece incorrect");
                return false;
            }
            return true;
        }

        public bool GetPieceByCell_test()
        {
            if (board.GetPiece(cellA) != piece)
            {
                Console.WriteLine("piece incorrect");
                return false;
            }
            
            if (board.GetPiece(cellB) != noPiece)
            {
                Console.WriteLine("noPiece incorrect");
                return false;
            }
            
            return true;
        }

        public bool MovePiece_test()
        {
            board.MovePiece(cellA, cellB);

            if (cellA.GetPiece().GetColor() != (int)Piece.colors.NoPiece)
            {
                Console.WriteLine("cell A has to be empty");
                return false;
            }

            if (cellB.GetPiece() != piece)
            {
                Console.WriteLine("cell B has to containe the same piece piece");
                return false;
            }

            return true;
        }

        public bool MovePiece_test2()
        {

            //Piece piece2 = new Piece((int)Piece.colors.White, new List<Position>());
            //Piece noPiece2 = new Piece((int)Piece.colors.NoPiece, new List<Position>());

            Cell cellA2 = new Cell(new Position(0, 0), new Piece((int)Piece.colors.White, new List<Position>()));
            Cell cellB2 = new Cell(new Position(0, 1), new Piece((int)Piece.colors.NoPiece, new List<Position>()));

            Cell[,] boardSample2 = new Cell[2, 1];
            boardSample2[0, 0] = cellA2;
            boardSample2[1, 0] = cellB2;

            Board board2 = new Board(boardSample2);

            int pieceId = cellA2.GetPiece().GetId();
            board2.MovePiece(cellA2, cellB2);

            if (cellB2.GetPiece().GetId() != pieceId)
            {
                Console.WriteLine("cell B has to containe the same piece piece");
                return false;
            }

            if (cellA2.GetPiece().GetColor() != (int)Piece.colors.NoPiece)
            {
                Console.WriteLine("cell A has to be empty");
                return false;
            }

            return true;
        }
    }
}
