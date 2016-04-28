using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class CellTest
    {
        private static Piece piece = new Piece();

        Cell cell = new Cell(new Position(1,1), piece);

        public bool GetBoardPosition_test()
        {
            if (cell.GetBoardPosition().horizontal != 1 || cell.GetBoardPosition().vertical != 1)
            {
                Console.WriteLine("Position incorrect");
                return false;
            }

            return true;
        }

        public bool GetPiece_test()
        {
            if (cell.GetPiece() != CellTest.piece)
            {
                Console.WriteLine("Piece incorrect");
                return false;
            }

            return true;
        }

        public bool SetEmptyPiece_test()
        {
            cell.SetEmptyCell();

            if (cell.GetPiece().GetColor() != (int)Piece.colors.NoPiece)
            {
                Console.WriteLine("Color has to be NoPiece");
                return false;
            }

            return true;
        }

        public bool Get_type_test()
        {
            if (cell.Get_type() != (int)Actor.types.Cell)
            {
                Console.WriteLine("type has to be cell");
                return false;
            }

            return true;
        }

    }
}
