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
            WhiteCellsAreWhite();
            BlackCellsAreBlack();
        }

        public bool IsMovementsCorrect()
        {
            if (!IsMovementLengthCorrect(3))
            {
                return false;
            }

            if (!IsOriginCellCorret(piecesToMove.movements[0].originCell, new Position(0, 0)) ||
                 !IsCellOfColor(piecesToMove.movements[0].originCell, (int) Piece.colors.White))
            {
                return false;
            }
            if (!IsOriginCellCorret(piecesToMove.movements[1].originCell, new Position(1, 0)) ||
                 !IsCellOfColor(piecesToMove.movements[1].originCell, (int)Piece.colors.White))
            {
                return false;
            }
            if (!IsOriginCellCorret(piecesToMove.movements[2].originCell, new Position(2, 0)) ||
                !IsCellOfColor(piecesToMove.movements[2].originCell, (int)Piece.colors.White))
            {
                return false;
            }

            if (!IsDestinyLengthCorrect(0, 1))
            {
                return false;
            }


            WhiteCellsAreWhite();

            Console.WriteLine("destiny cell 0 color: " + piecesToMove.movements[1].destinyCells[0].GetPiece().GetColor());
            Console.WriteLine("destiny cell 0 pos: " + piecesToMove.movements[1].destinyCells[0].GetBoardPosition().horizontal + piecesToMove.movements[1].destinyCells[0].GetBoardPosition().vertical );

            Console.WriteLine("destiny cell 1 color" + piecesToMove.movements[1].destinyCells[1].GetPiece().GetColor());
            Console.WriteLine("destiny cell 1 pos: " + piecesToMove.movements[1].destinyCells[1].GetBoardPosition().horizontal + piecesToMove.movements[1].destinyCells[1].GetBoardPosition().vertical);

          

            if (!IsDestinyLengthCorrect(1, 1))
            {

                Console.WriteLine(piecesToMove.movements[1].destinyCells[0].GetBoardPosition().horizontal + ", " +
                    piecesToMove.movements[1].destinyCells[0].GetBoardPosition().vertical);

                Console.WriteLine(piecesToMove.movements[1].destinyCells[1].GetBoardPosition().horizontal + ", " +
                    piecesToMove.movements[1].destinyCells[1].GetBoardPosition().vertical);


                return false;
            }
            if (!IsDestinyLengthCorrect(2, 1))
            {
                return false;
            }



            return true;
            
        }

        private bool IsMovementLengthCorrect(int length)
        {
            if (piecesToMove.movements.Count != length)
            {
                Console.WriteLine("Length incorrect, now is: " + piecesToMove.movements.Count);
                return false;
            }
            return true;
        }



        private bool IsOriginCellCorret(Cell cell , Position pos)
        {
            if (cell.GetBoardPosition().horizontal != pos.horizontal ||
                cell.GetBoardPosition().vertical != pos.vertical)
            {
                Console.WriteLine("OriginCell incorrect, is " + cell.GetBoardPosition().horizontal + ", " +  cell.GetBoardPosition().vertical);
                return false;
            }
            return true;
        }

        private bool IsDestinyLengthCorrect(int movement, int length)
        {
            if (piecesToMove.movements[movement].destinyCells.Count != length)
            {
                Console.WriteLine("Destiny Length incorrect in movemenst: " + movement +", now is: " + piecesToMove.movements[movement].destinyCells.Count);
                
                return false;
            }
            return true;
        }

        private bool IsDestinyCellCorret(Cell cell, Position pos)
        {
            if (cell.GetBoardPosition().horizontal != pos.horizontal ||
                cell.GetBoardPosition().vertical != pos.vertical)
            {
                Console.WriteLine("DestinynCell incorrect, is " + cell.GetBoardPosition().horizontal + ", " + cell.GetBoardPosition().vertical);
                return false;
            }
            return true;
        }

        private bool IsCellOfColor( Cell cell, int color)
        {
            if (cell.GetPiece().GetColor() != color)
            {
                Console.WriteLine("Color wrong");
                return false;
            }
            return true;
        }


        private bool WhiteCellsAreWhite()
        {
            int color = (int)Player.colors.White;
            
            if (!IsCellOfColor(board.GetCell(0, 0), color))
            {
                Console.WriteLine("0,0 Wrong is: " + board.GetCell(0, 0).GetPiece().GetColor());
            }
            if (!IsCellOfColor(board.GetCell(1, 0), color))
            {
                Console.WriteLine("1, 0 Wrong  is: " + board.GetCell(1, 0).GetPiece().GetColor());
            }
            if (!IsCellOfColor(board.GetCell(2, 0), color))
            {
                Console.WriteLine("2, 0 Wrong  is: " + board.GetCell(2, 0).GetPiece().GetColor());
            }
            return true;
        }

        private bool BlackCellsAreBlack()
        {
            int color = (int)Player.colors.Black;

            if (!IsCellOfColor(board.GetCell(0 , 2), color))
            {
                Console.WriteLine("0,2 Wrong  is: " + board.GetCell(0, 2).GetPiece().GetColor());
            }
            if (!IsCellOfColor(board.GetCell(1, 2), color))
            {
                Console.WriteLine("1,2 Wrong  is: " + board.GetCell(1, 2).GetPiece().GetColor());
            }
            if (!IsCellOfColor(board.GetCell(2, 2), color))
            {
                Console.WriteLine("2,2 Wrong  is: " + board.GetCell(2, 2).GetPiece().GetColor());
            }
            return true;
        }

    }
}
