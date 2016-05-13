using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Test_Action
    {
        
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


            Cell cellA = new Cell(new Position(1,1), new Piece(white,new List<Position>()));
            Action action = new Action(cellA);

            test.RunTest(ActionTest2(cellA, action), "ActionTest2_A");

            Cell cellB = new Cell(new Position(4, 1), new Piece(black, new List<Position>()));

            test.RunTest(!ActionTest2(cellB, action), "ActionTest2_B");


            action.destinyCells.Add(cellA);
            test.RunTest(ActionTest3(cellA, action), "ActionTest3_A");

            test.RunTest(!ActionTest3(cellB, action), "ActionTest3_B");


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

        public bool ActionTest2(Cell cell, Action action)
        {
            bool result = true;
            
            if (!action.IsCellInOrigin(cell))
            {
                test.Report("Cell no corret. id's = ",cell.GetId(), action.originCell.GetId() );
                result = false;
            }

            return result;
        }

        public bool ActionTest3(Cell cell, Action action)
        {
            bool result = true;

            if (!action.IsCellInDestiny(cell))
            {
                test.Report("Cell no corret. id's = ", cell.GetId(), action.originCell.GetId());
                result = false;
            }
            

            return result;
        }


    }
}
