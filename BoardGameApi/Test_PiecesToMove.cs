using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Test_PiecesToMove
    {
        TestRunner test = new TestRunner();

        public Test_PiecesToMove()
        {
            test.RunTest(Test_A(), "PiecesToMove_TestA");
            //test.RunTest(Test_B(), "PiecesToMove_TestB");
            //test.RunTest(Test_C(), "PiecesToMove_TestC");

        }



        bool Test_A()
        {
            bool result = true;

            BoardGameFactory boardFactory = new BoardGameFactory();
            Board board = boardFactory.MakeBoard((int)BoardGameFactory.names.AllWhitePieces);
            Player playerW = new Player((int)Player.colors.White);

            PiecesToMove_Standard(board, playerW);
            BasicMovementsAvailable();

            if (movements.Count != 0)
            {
                test.Report("movements Lenght incorrect", 0, movements.Count);
                result = false;
            }



            return result; 
        }

        bool Test_B()
        {
            bool result = true;

            BoardGameFactory boardFactory = new BoardGameFactory();
            Board board = boardFactory.MakeBoard((int)BoardGameFactory.names.AllBlackPieces);
            Player playerW = new Player((int)Player.colors.Black);

            PiecesToMove_Standard(board, playerW);
            BasicMovementsAvailable();

            if (movements.Count != 0)
            {
                test.Report("movements Lenght incorrect", 0, movements.Count);
                result =  false;
            }



            return result;
        }

        bool Test_C()
        {
            bool result = true;

            BoardGameFactory boardFactory = new BoardGameFactory();
            Board board = boardFactory.MakeBoard((int)BoardGameFactory.names.Standard);
            Player playerW = new Player((int)Player.colors.White);

            PiecesToMove_Standard(board, playerW);
            BasicMovementsAvailable();

            if (movements.Count != 3)
            {
                test.Report("movements Lenght incorrect", 3, movements.Count);
                result = false;
            }

            return false;
        }







        /// COPY From ORIGINAL
        private Board board;
        private Player currentPlayer;

        public List<Action> movements;

        public void PiecesToMove_Standard(Board board, Player currentPlayer)
        {
            this.board = board;
            movements = new List<Action>();
            this.currentPlayer = currentPlayer;
        }


        public void BasicMovementsAvailable()
        {
            movements.Clear();

            Cell[,] boardTable = this.board.GetBoard();
            Piece pieceAux;

            Action newMove;

            foreach (Cell cell in boardTable)
            {
                pieceAux = cell.GetPiece();

                if (board.IsPlayerPiece(cell, currentPlayer))
                {
                    newMove = new Action(cell, board.CellsInRange(cell, cell.GetPiece().GetBasicMovement()));
                    newMove.NoPlayerCellsInDestiny(currentPlayer);
                    movements.Add(newMove);
                }

            }
        }
        /// END COPY From ORIGINAL
    }
}
