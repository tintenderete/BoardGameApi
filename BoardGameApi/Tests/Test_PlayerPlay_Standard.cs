using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Test_PlayerPlay_Standard
    {
        PlayerPlay_Standard playerPlay_Standard;
        Player playerW;
        Player playerB;
        TestRunner test;

        public Test_PlayerPlay_Standard()
        {
            
            test = new TestRunner();
            playerW = new Player((int)Player.colors.White);
            playerB = new Player((int)Player.colors.Black);

            Cell originA = new Cell(new Position(0, 0), new Piece((int)Piece.colors.White, new List<Position>()));
            Cell originB = new Cell(new Position(1, 1), new Piece((int)Piece.colors.White, new List<Position>()));
            Cell originC = new Cell(new Position(2, 2), new Piece((int)Piece.colors.White, new List<Position>()));

            Cell destinyA1 = new Cell(new Position(1, 0), new Piece((int)Piece.colors.Black, new List<Position>()));

            Cell destinyB1 = new Cell(new Position(2, 0), new Piece((int)Piece.colors.Black, new List<Position>()));
            Cell destinyB2 = new Cell(new Position(3, 0), new Piece((int)Piece.colors.Black, new List<Position>()));

            Cell destinyC1 = new Cell(new Position(4, 0), new Piece((int)Piece.colors.Black, new List<Position>()));
            Cell destinyC2 = new Cell(new Position(5, 0), new Piece((int)Piece.colors.Black, new List<Position>()));
            Cell destinyC3 = new Cell(new Position(6, 0), new Piece((int)Piece.colors.Black, new List<Position>()));
            Cell destinyC4 = new Cell(new Position(7, 0), new Piece((int)Piece.colors.Black, new List<Position>()));

            List<Cell> destinyA = new List<Cell>();
            destinyA.Add(destinyA1);

            List<Cell> destinyB = new List<Cell>();
            destinyB.Add(destinyB1);
            destinyB.Add(destinyB2);

            List<Cell> destinyC = new List<Cell>();
            destinyC.Add(destinyC1);
            destinyC.Add(destinyC2);
            destinyC.Add(destinyC3);
            destinyC.Add(destinyC4);


            Action actionA = new Action(originA, destinyA);
            Action actionB = new Action(originB, destinyB);
            Action actionC = new Action(originC, destinyC);


            List<Action> movementsAvailable = new List<Action>();
            movementsAvailable.Add(actionA);
            movementsAvailable.Add(actionB);
            movementsAvailable.Add(actionC);

            List<Actor> inputsTest1A = new List<Actor>();
            Cell cellTest1A_1 = originB;
            Cell cellTest1A_2 = destinyB2;
            inputsTest1A.Add(cellTest1A_1);
            inputsTest1A.Add(cellTest1A_2);

            List<Actor> inputsTest1B = new List<Actor>();
            Cell cellTest1B_1 = originB;
            Cell cellTest1B_2 = destinyC1;
            inputsTest1B.Add(cellTest1B_1);
            inputsTest1B.Add(cellTest1B_2);

            List<Actor> inputsTest1C = new List<Actor>();
            Cell cellTest1C_1 = new Cell(new Position(3, 3), new Piece((int)Piece.colors.Black, new List<Position>()));
            Cell cellTest1C_2 = destinyB2;
            Cell cellTest1C_3 = destinyC1;
            inputsTest1C.Add(cellTest1C_1);
            inputsTest1C.Add(cellTest1C_2);
            inputsTest1C.Add(cellTest1C_3);

            List<Actor> inputsTest1D = new List<Actor>();
            Cell cellTest1D_1 = new Cell(new Position(3, 3), new Piece((int)Piece.colors.White, new List<Position>()));
            inputsTest1C.Add(cellTest1C_1);

            List<Actor> inputsTest1E = new List<Actor>();
            Cell cellTest1E_1 = originB;
            inputsTest1E.Add(cellTest1E_1);

            List<Actor> inputsTest1F = new List<Actor>();
            Cell cellTest1F_1 = new Cell(new Position(3, 3), new Piece((int)Piece.colors.White, new List<Position>())); ;
            Cell cellTest1F_2 = new Cell(new Position(5, 5), new Piece((int)Piece.colors.Black, new List<Position>())); ; ;
            inputsTest1F.Add(cellTest1F_1);
            inputsTest1F.Add(cellTest1F_2);


            Action expectedActionTest1A = new Action(cellTest1A_1, new List<Cell>() { cellTest1A_2 });
            Action expectedActionTest1B = null;
            Action expectedActionTest1C = null;
            Action expectedActionTest1D = null;
            Action expectedActionTest1E = null;
            Action expectedActionTest1F = null;



            //Test A
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1A;
            playerPlay_Standard.currentPlayer = playerW;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1A), "PlayerPlay_Standard Test1A  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 0 , null), "PlayerPlay_Standard Test1A  CheckFinalInputs ");

            //Test B
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1B;
            playerPlay_Standard.currentPlayer = playerW;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1B), "PlayerPlay_Standard Test1B  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 1, cellTest1B_1), "PlayerPlay_Standard Test1B  CheckFinalInputs ");

            //Test C
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1C;
            playerPlay_Standard.currentPlayer = playerB;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1C), "PlayerPlay_Standard Test1C  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 0, null), "PlayerPlay_Standard Test1C  CheckFinalInputs ");

            //Test D
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1D;
            playerPlay_Standard.currentPlayer = playerW;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1D), "PlayerPlay_Standard Test1D  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 0, null), "PlayerPlay_Standard Test1D  CheckFinalInputs ");

            //Test E
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1E;
            playerPlay_Standard.currentPlayer = playerW;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1E), "PlayerPlay_Standard Test1E  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 1, originB), "PlayerPlay_Standard Test1E  CheckFinalInputs ");

            //Test F
            playerPlay_Standard = new PlayerPlay_Standard();
            playerPlay_Standard.movementsAvailable = movementsAvailable;
            playerPlay_Standard.inputs = inputsTest1F;
            playerPlay_Standard.currentPlayer = playerW;
            playerPlay_Standard.nextMovement = playerPlay_Standard.DidPlayerDoAnyMovementAvailable();

            test.RunTest(CheckNewMovement(playerPlay_Standard.nextMovement, expectedActionTest1F), "PlayerPlay_Standard Test1F  CheckNewMovement ");
            test.RunTest(CheckFinalInputs(playerPlay_Standard.inputs, 0, null), "PlayerPlay_Standard Test1F  CheckFinalInputs ");

        }

        public bool CheckNewMovement(Action recivedAction, Action expectedAction)
        {
            bool result = true;
            if (expectedAction == null && recivedAction != null)
            {
                test.Report("recivedAction  ", "null",
                                    "no null");
                return false;
            }
            if (expectedAction != null && recivedAction == null)
            {
                test.Report("recivedAction ", "No null" ,
                    "null");
                return false;
            }
            if (expectedAction == null || recivedAction == null)
            {
                return true;
            }
            if (recivedAction.originCell != expectedAction.originCell)
            {
                test.Report("OriginCell wrong", expectedAction.originCell.GetBoardPosition().horizontal, 
                    recivedAction.originCell.GetBoardPosition().horizontal);
                result = false;
            }

            if (recivedAction.destinyCells[0] != expectedAction.destinyCells[0])
            {
                test.Report("DestinyCell wrong", expectedAction.destinyCells[0].GetBoardPosition().horizontal,
                    recivedAction.destinyCells[0].GetBoardPosition().horizontal);
                result = false;
            }

            return result;
        }


        public bool CheckFinalInputs(List<Actor> inputs ,int ExpectedInputsLength, Cell cell )
        {
            bool result = true;

            if (inputs.Count != ExpectedInputsLength)
            {
                test.Report("Final Inputs length wrong", ExpectedInputsLength, inputs.Count);
                result = false;
            }
            if (inputs.Count > 0)
            {
                if (cell != inputs[0])
                {
                    test.Report("Final Inputs cell wrong", cell, inputs[0]);
                    result = false;
                }
            }

            return result;
        }

        
            

           


     

    }
}
