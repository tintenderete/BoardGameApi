using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Test_NoEnemyPieces
    {
        TestRunner test = new TestRunner();

        public Test_NoEnemyPieces()
        {
            BoardGameFactory factory = new BoardGameFactory();

            Player playerW = new Player((int)Player.colors.White);
            Player playerB = new Player((int)Player.colors.Black);

            Board board = factory.MakeBoard((int)BoardGameFactory.names.AllWhitePieces);

            test.RunTest(NoEnemyPieces.Control(board, playerW), "EnemyNoPieces Test1_A" );

            board = factory.MakeBoard((int)BoardGameFactory.names.AllBlackPieces);

            test.RunTest(!NoEnemyPieces.Control(board, playerW), "EnemyNoPieces Test1_B");
            
            board = factory.MakeBoard((int)BoardGameFactory.names.Standard);

            test.RunTest(!NoEnemyPieces.Control(board, playerB), "EnemyNoPieces Test1_C");

            test.RunTest(!NoEnemyPieces.Control(board, playerW), "EnemyNoPieces Test1_D");

        }
    }
}