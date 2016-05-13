using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class TestFacade
    {
        public TestFacade()
        {
            PiecesToMove_Standard_Test piecesToMove_Standard_Test = new PiecesToMove_Standard_Test();

            Test_Action test_Action = new Test_Action();

            Test_Board test_Board = new Test_Board();

            Test_BoardTableEditor test_BoardTableEditor = new Test_BoardTableEditor();

            Test_PiecesToMove test_PiecesToMove = new Test_PiecesToMove();

            Test_PlayerPlay_Standard test_playerPlay_Standard = new Test_PlayerPlay_Standard();


            Console.WriteLine("");
            Console.WriteLine("tests FINISHED");
            Console.ReadKey();

        }
    }
}
