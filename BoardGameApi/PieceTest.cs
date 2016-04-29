using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PieceTest
    {

        Piece Wpiece;
        Piece Bpiece;
        Piece Nopiece;

        public PieceTest()
        {
            Wpiece = new Piece((int)Piece.colors.White, new List<Position>());
            Bpiece = new Piece((int)Piece.colors.Black, new List<Position>());
            Nopiece = new Piece((int)Piece.colors.NoPiece, new List<Position>());
        }

        public bool GetColor_test()
        {
            if (Wpiece.GetColor() != (int)Piece.colors.White)
            {
                Console.WriteLine("Wpiece has to be white and the result is: " + Wpiece.GetColor());
                return false;
            }
            if (Bpiece.GetColor() != (int)Piece.colors.Black)
            {
                Console.WriteLine("Bpiece has to be black and the result is: " + Bpiece.GetColor());
                return false;
            }
            if (Nopiece.GetColor() != (int)Piece.colors.NoPiece)
            {
                Console.WriteLine("Nopiece has to be NoPiece and the result is: " + Nopiece.GetColor());
                return false;
            }

            return true;
        }

        public bool GetBasicMovement_test()
        {
            if (Wpiece.GetBasicMovement().Count != 0)
            {
                Console.WriteLine("The W movement has to be a empty list and is: " + Wpiece.GetBasicMovement());
                return false;
            }
            if (Bpiece.GetBasicMovement().Count != 0)
            {
                Console.WriteLine("The B movement has to be a empty list and is: " + Bpiece.GetBasicMovement());
                return false;
            }
            if (Nopiece.GetBasicMovement().Count != 0)
            {
                Console.WriteLine("The No movement has to be a empty list and is: " + Nopiece.GetBasicMovement());
                return false;
            }

            return true;
        }

        public bool GetType_test()
        {

            if (Wpiece.Get_type() != (int)Actor.types.Piece)
            {
                Console.WriteLine("The W type has to be a piece");
                return false;
            }

            if (Bpiece.Get_type() != (int)Actor.types.Piece)
            {
                Console.WriteLine("The B type has to be a piece");
                return false;
            }

            if (Nopiece.Get_type() != (int)Actor.types.Piece)
            {
                Console.WriteLine("The No type has to be a piece");
                return false;
            }

            return true;
        }


    }
}
