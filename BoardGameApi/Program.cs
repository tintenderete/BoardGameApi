﻿using System;
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
           
            ActorTest actorTest = new ActorTest();

            if (!actorTest.idCorrect())
            {
                Console.WriteLine("Actor id no correct"); 
            }

            if (!actorTest.idDiferent())
            {
                Console.WriteLine("Actor id is repited");
            }

            if (!actorTest.idCountGotMax())
            {
                Console.WriteLine("Actor idCount dosent count well");
            }

            PieceTest pieceTest = new PieceTest();

            if (!pieceTest.GetColor_test())
            {
                Console.WriteLine("Color incorrect");
            }

            if (!pieceTest.GetBasicMovement_test())
            {
                Console.WriteLine("Basic Movement incorrect");
            }

            if (!pieceTest.GetType_test())
            {
                Console.WriteLine("type actor incorrect");
            }

            CellTest cellTest = new CellTest();

            if (!cellTest.GetBoardPosition_test())
            {
                Console.WriteLine("Board Position incorrect");
            }

            if (!cellTest.GetPiece_test())
            {
                Console.WriteLine("Piece incorrect");
            }

            if (!cellTest.SetEmptyPiece_test())
            {
                Console.WriteLine("Cell no empty");
            }

            if (!cellTest.Get_type_test())
            {
                Console.WriteLine("has to be a cell");
            }

            if (!cellTest.isEmpty_test())
            {
                Console.WriteLine("empty method failed");
            }


            Console.WriteLine("test finished");
            Console.ReadKey();
        }
        
    }
}
