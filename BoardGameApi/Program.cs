using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameApi;

namespace BoardGameApi
{
    class Program
    {

        
        static void Main(string[] args)
        {
            // Piece
            List<Position> PieceMovements = new List<Position>();
            PieceMovements[0] = new Position(1, 0);
            PieceMovements[1] = new Position(-1, 0);
            PieceMovements[2] = new Position(0, 1);
            PieceMovements[3] = new Position(0, -1);

            Piece whitePiece = new Piece((int)Piece.colors.White, PieceMovements);
            Piece noPiece = new Piece((int)Piece.colors.White, new List<Position>());

            



        }
        
    }
}
