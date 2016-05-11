using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Test_Action
    {
        int noPiece = 0;
        int white = 1;
        int black = 2;
        TestRunner test = new TestRunner();

        public Test_Action()
        {
            Player playerB = new Player((int)Player.colors.Black);
            List<Cell> destiny = new List<Cell>();
            
            destiny.Add(new Cell(new Position(1, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(2, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(3, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(4, 0), new Piece(black, null)));

            test.RunTest(ActionTest1(destiny, playerB, 0), "ActionTest1_A");

            destiny = new List<Cell>();

            destiny.Add(new Cell(new Position(1, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(2, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(3, 0), new Piece(white, null)));
            destiny.Add(new Cell(new Position(2, 0), new Piece(black, null)));
            destiny.Add(new Cell(new Position(4, 0), new Piece(white, null)));

            test.RunTest(ActionTest1(destiny, playerB, 2), "ActionTest1_B");
        }
        

        public bool ActionTest1(List<Cell> cellList, Player player, int lengthExpected)
        {

            bool result = true;

            Action action = new Action(new Cell(), cellList);

            action.NoPlayerCellsInDestiny(player);

            if (action.destinyCells.Count != lengthExpected)
            {
                test.Report("Length wrong", lengthExpected, action.destinyCells.Count);
                result = false;
            }


            return result;
        }


    }
}
