using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Test_GameSimulation
    {
        TestRunner test = new TestRunner();
        int playerW = 1;
        int playerB = 2;
        int noPiece = 0;

        TurnManager turnManager;
        Board board;
        Cell[,] boardTable;
        Game game;

        public Test_GameSimulation()
        {

            turnManager = new TurnManager();
            turnManager.AddStep(new PiecesToMove_Standard());
            turnManager.AddStep(new PlayerPlay_Standard());
            
            BoardGameFactory factory = new BoardGameFactory();

            board = factory.MakeBoard((int)BoardGameFactory.names.Standard);
            boardTable = board.GetBoard();

            game = new Game(board, turnManager);

            turnManager.SetGame(game);

            List<Actor> movement = new List<Actor> { boardTable[1, 0], boardTable[1, 1] };

            Turn(1, movement);

            test.RunTest( IsCellCorrect(boardTable[1, 1], playerW) , "IsCellCorrect");
            test.RunTest( IsCellCorrect(boardTable[1, 0], noPiece), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[1, 2], boardTable[1, 1]};

            Turn(2, movement);

            test.RunTest(IsCellCorrect(boardTable[1, 2], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[1, 1], playerB), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[1, 0], noPiece), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[0, 0], boardTable[0, 1] };

            Turn(3, movement);

            test.RunTest(IsCellCorrect(boardTable[0, 1], playerW), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[0, 0], noPiece), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[1, 1], boardTable[1, 2] };

            Turn(4, movement);

            test.RunTest(IsCellCorrect(boardTable[1, 2], playerB), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[1, 1], noPiece), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[0, 1], boardTable[0, 2] };

            Turn(5, movement);

            test.RunTest(IsCellCorrect(boardTable[0, 1], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[0, 2], playerW), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[1, 2], boardTable[0, 2] };

            Turn(6, movement);

            test.RunTest(IsCellCorrect(boardTable[1, 2], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[0, 2], playerB), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[2, 0], boardTable[2, 1] };

            Turn(7, movement);

            test.RunTest(IsCellCorrect(boardTable[2, 1], playerW), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[2, 0], noPiece), "IsCellCorrect");
            test.RunTest(!NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            game.NexPlayer();

            movement = new List<Actor>() { boardTable[2, 2], boardTable[2, 1] };

            Turn(8, movement);

            test.RunTest(IsCellCorrect(boardTable[2, 1], playerB), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[2, 2], noPiece), "IsCellCorrect");
            test.RunTest(NoEnemyPieces.Control(board, game.GetCurrentPlayer()), "NoEnemyPieces");

            Console.WriteLine("Check final boardTable");

            test.RunTest(IsCellCorrect(boardTable[0, 0], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[0, 1], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[0, 2], playerB), "IsCellCorrect");

            test.RunTest(IsCellCorrect(boardTable[1, 0], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[1, 1], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[1, 2], noPiece), "IsCellCorrect");

            test.RunTest(IsCellCorrect(boardTable[2, 0], noPiece), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[2, 1], playerB), "IsCellCorrect");
            test.RunTest(IsCellCorrect(boardTable[2, 2], noPiece), "IsCellCorrect");





        }


        public void Turn(int turn, List<Actor> movements)
        {
            Console.WriteLine("Turn " + turn + " :");

            //PiecesToMove_Standard
            game.Update();
            
            game.GetCurrentPlayer().SetInputs(movements);

            //PlayerPlay_Standard
            game.Update();
        }


        public bool IsCellCorrect(Cell cell,  int colorPiece)
        {
            if (cell.GetPiece().GetColor() == colorPiece)
            {
                return true;
            }

            test.Report("Color in cell"+ cell.GetBoardPosition().horizontal + cell.GetBoardPosition().vertical + " wrong", colorPiece, cell.GetPiece().GetColor());

            return false;
        }

    }
}