using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class ActorTest
    {
        /*
         Each class has a diferent id.
         Id count increase in each class declaration
         */


        public bool idCorrect()
        {
            int numPieces = 10;
            Piece[] pieceList = new Piece[numPieces];

            for (int i = 0; i < 10; i++)
            {
                pieceList[i] = new Piece();

                if (pieceList[i].GetId() != Actor.GetCount() - 1)
                {
                    Console.WriteLine( "idPiece: " + pieceList[i].GetId() + ", ActorCount: " + Actor.GetCount());
                    return false;
                }
            }

            return true;

        }

        public bool idDiferent()
        {
            int numPieces = 10;
            Piece[] pieceList = new Piece[numPieces];

            for (int i = 0; i < 10; i++)
            {
                pieceList[i] = new Piece();
                if (i == 0){continue;}
                
                if (pieceList[i].GetId() == pieceList[i - 1].GetId())
                {
                    
                        Console.WriteLine("idPiece i: " + pieceList[i].GetId() + ", idPiece i - 1: " + pieceList[i - 1].GetId());
                        return false;
                    }   
            }

            return true;

        }

        public bool idCountGotMax()
        {
            Actor.ResetCount();
            int numPieces = 10;
            Piece[] pieceList = new Piece[numPieces];

            for (int i = 0; i < 10; i++)
            {
                pieceList[i] = new Piece();
            }

            if (Actor.GetCount() != numPieces)
            {
                Console.WriteLine("ActorCount: " + Actor.GetCount() + ", numPieces: " + numPieces);
                return false;
            }

            return true;

        }
    }
}
