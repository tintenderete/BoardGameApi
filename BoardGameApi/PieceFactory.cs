using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PieceFactory
    {
        public enum names {standard_White, standard_Black };

        public Piece MakePiece(int pieceName)
        {
            Piece newPiece;
            List<Position> movementSkill = new List<Position>();

            if (pieceName == (int)names.standard_White)
            {
                movementSkill[0] = new Position(0, 1);
                movementSkill[1] = new Position(0, -1);
                movementSkill[2] = new Position(1, 0);
                movementSkill[4] = new Position(-1, 0);
                 
                newPiece = new Piece((int)Piece.colors.White, movementSkill);

                return newPiece;
            }

            return new Piece((int)Piece.colors.NoPiece, movementSkill);


            
        }
    }
}
