using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Test_Board
    {
        BoardGameFactory boardFactory;
        Board board;
        TestRunner test;
        public Test_Board()
        {
            test = new TestRunner();
            boardFactory = new BoardGameFactory();

            test.RunTest(BoardTest_A((int)BoardGameFactory.names.AllWhitePieces), "BoardTest_A whites : all Gets works");
            test.RunTest(BoardTest_A((int)BoardGameFactory.names.AllBlackPieces), "BoardTest_A blacks : all Gets works");
            test.RunTest(BoardTest_A((int)BoardGameFactory.names.AllNoPieces), "BoardTest_A noPieces : all Gets works");

            test.RunTest(BoardTest_B((int)BoardGameFactory.names.AllWhitePieces), "BoardTest_B whites : cellInRange -  output.Length ");
            test.RunTest(BoardTest_B((int)BoardGameFactory.names.AllBlackPieces), "BoardTest_B blacks : cellInRange - output.Length ");

            List<Position> nextCells17 = new List<Position>();
            nextCells17.Add(new Position(0, 7));
            nextCells17.Add(new Position(2, 7));
            nextCells17.Add(new Position(1, 6));
            Cell cell17 = board.GetCell(1, 7);

            test.RunTest(BoardTest_C(cell17, nextCells17), "BoardTest_C. Cell: 1 7 : cellInRange - cells position checked");

            List<Position> nextCells37 = new List<Position>();
            nextCells37.Add(new Position(2, 7));
            nextCells37.Add(new Position(4, 7));
            nextCells37.Add(new Position(3, 6));
            Cell cell37 = board.GetCell(3, 7);

            test.RunTest(BoardTest_C(cell37, nextCells37), "BoardTest_C. Cell: 3 7 : cellInRange - cells position checked");

            List<Position> nextCells77 = new List<Position>();
            nextCells77.Add(new Position(6, 7));
            nextCells77.Add(new Position(7, 6));
            Cell cell77 = board.GetCell(7, 7);

            test.RunTest(BoardTest_C(cell77, nextCells77), "BoardTest_C. Cell: 7 7 : cellInRange - cells position checked");

            List<Position> nextCells35 = new List<Position>();
            nextCells35.Add(new Position(3, 6));
            nextCells35.Add(new Position(2, 5));
            nextCells35.Add(new Position(3, 4));
            nextCells35.Add(new Position(4, 5));
            Cell cell35 = board.GetCell(3, 5);

            test.RunTest(BoardTest_C(cell35, nextCells35), "BoardTest_C. Cell: 3 5 : cellInRange - cells position checked");

            List<Position> nextCells72 = new List<Position>();
            nextCells72.Add(new Position(7, 3));
            nextCells72.Add(new Position(6, 2));
            nextCells72.Add(new Position(7, 1));
            Cell cell72 = board.GetCell(7, 2);

            test.RunTest(BoardTest_C(cell72, nextCells72), "BoardTest_C. Cell: 7 2 : cellInRange - cells position checked");

            List<Position> nextCells10 = new List<Position>();
            nextCells10.Add(new Position(0, 0));
            nextCells10.Add(new Position(1, 1));
            Cell cell10 = board.GetCell(1, 0);

            test.RunTest(BoardTest_C(cell10, nextCells10), "BoardTest_C. Cell: 1 0 : cellInRange - cells position checked");

            List<Position> nextCells03 = new List<Position>();
            nextCells03.Add(new Position(0, 4));
            nextCells03.Add(new Position(1, 3));
            nextCells03.Add(new Position(0, 2));
            Cell cell03 = board.GetCell(0, 3);

            test.RunTest(BoardTest_C(cell03, nextCells03), "BoardTest_C. Cell: 0 3 : cellInRange - cells position checked");

            List<Position> nextCells00 = new List<Position>();
            nextCells00.Add(new Position(1, 0));
            nextCells00.Add(new Position(0, 1));
            Cell cell00 = board.GetCell(0, 0);

            test.RunTest(BoardTest_C(cell00, nextCells00), "BoardTest_C. Cell: 0 0 : cellInRange - cells position checked");

            List<Position> nextCells01 = new List<Position>();
            nextCells01.Add(new Position(0, 0));
            nextCells01.Add(new Position(1, 1));
            nextCells01.Add(new Position(0, 2));
            Cell cell01 = board.GetCell(0, 1);

            test.RunTest(BoardTest_C(cell01, nextCells01), "BoardTest_C. Cell: 0 1 : cellInRange - cells position checked");

            List<Position> nextCells02 = new List<Position>();
            nextCells02.Add(new Position(0, 3));
            nextCells02.Add(new Position(1, 2));
            nextCells02.Add(new Position(0, 1));
            Cell cell02 = board.GetCell(0, 2);

            test.RunTest(BoardTest_C(cell02, nextCells02), "BoardTest_C. Cell: 0 2 : cellInRange - cells position checked");
        }

        private bool BoardTest_A(int boardName)
        {
            bool result = true;
            board = boardFactory.MakeBoard(boardName);
            Cell[,] boardTable = board.GetBoard();
           
            for (int v = 0; v < board.GetSize().vertical; v++)
            {
                for (int h = 0; h < board.GetSize().horizontal; h++)
                {
                    Cell cell = board.GetCell(h, v);

                    if (cell != boardTable[h, v])
                    {
                        test.Report("Board.GetCell by position incorrect", boardTable[h, v] , board.GetCell(h, v));
                        result = false;
                    }

                    Position boardPosition = cell.GetBoardPosition();
                    
                    if (boardPosition.horizontal != new Position(h, v).horizontal ||
                        boardPosition.vertical != new Position(h, v).vertical)
                    {
                        test.Report("Cell.GetBoardPosition incorrect", h + v , boardPosition.horizontal + boardPosition.vertical);
                        result = false;
                    }

                    Piece piece = board.GetPiece(h, v);

                    if (piece.GetId() != boardTable[h, v].GetPiece().GetId())
                    {
                        test.Report("Board.GetPiece by position incorrect", boardTable[h, v].GetPiece().GetId(), piece.GetId());
                        result = false;
                    }

                    cell = board.GetCell(piece);

                    if (cell.GetBoardPosition().horizontal != new Position(h, v).horizontal ||
                        cell.GetBoardPosition().vertical != new Position(h, v).vertical)
                    {
                        test.Report("Board.GetCell by cell incorrect", h + v , cell.GetBoardPosition().horizontal + cell.GetBoardPosition().vertical);
                        result = false;
                    }

                    piece = board.GetPiece(cell);

                    if (piece != boardTable[h, v].GetPiece())
                    {
                        test.Report("Board.GetPiece by piece incorrect", piece.GetId(), boardTable[h, v].GetPiece().GetId());
                        result = false;
                    }


                    
                }
            }
            return result;

        }

        private bool BoardTest_B(int boardName)
        {
            bool result = true;
            board = boardFactory.MakeBoard(boardName);
            Cell[,] boardTable = board.GetBoard();

            Cell cell;
            List<Position> movement;
            List<Cell> nextCells;

            for (int v = 0; v < board.GetSize().vertical; v++)
            {
                for (int h = 0; h < board.GetSize().horizontal; h++)
                {
                    cell = board.GetCell(h, v);
                    movement = cell.GetPiece().GetBasicMovement();

                    nextCells = board.CellsInRange(cell, movement);

                    Position size = board.GetSize();
                    // Left and Right size
                    if ((h == 0 || h == size.horizontal - 1) && (v > 0 && v < size.vertical - 1) )
                    {
                        if (nextCells.Count != 3)
                        {
                            test.Report("Board.CellsInRange in pos: " + h + v + " incorrect", 3, nextCells.Count);
                            result = false;
                        }
                    }
                    // Corners
                    else if (h == 0 && v == size.vertical - 1 ||
                        h == size.horizontal - 1 && v == size.vertical - 1 ||
                        h == 0 && v == 0 ||
                        h == size.horizontal - 1 && v == 0)
                    {
                        if (nextCells.Count != 2)
                        {
                            test.Report("Board.CellsInRange in pos: " + h + v + " incorrect", 2, nextCells.Count);
                            result = false;
                        }
                    }
                    // Top and botoom without corners
                    else if ((h > 0 && h < size.horizontal - 1) && v == size.vertical - 1 ||
                        (h > 0 && h < size.horizontal - 1) && v == 0)
                    {
                        if (nextCells.Count != 3)
                        {
                            test.Report("Board.CellsInRange in pos: " + h + v + " incorrect", 3, nextCells.Count);
                            result = false;
                        }
                    }
                    // Central size
                    else
                    { 
                        if (nextCells.Count != 4)
                        {
                            test.Report("Board.CellsInRange in pos: " + h + v + " incorrect", 4, nextCells.Count);
                            result = false;
                        }
                    }

                }
            }

            return result;
        }

        private bool BoardTest_C(Cell cell, List<Position> expectedResults)
        {
            bool result = true;
            
            List<Cell> cellToTest = board.CellsInRange(cell, cell.GetPiece().GetBasicMovement());
            Position posFromCellsInRange = new Position(0, 0);
            bool isHere;

            for (int e = 0; e < expectedResults.Count; e++)
            {
                isHere = false;

                for (int i = 0; i < cellToTest.Count; i++)
                {
                    posFromCellsInRange = cellToTest[i].GetBoardPosition();
                    
                    if (expectedResults[e].horizontal == posFromCellsInRange.horizontal &&
                        expectedResults[e].vertical == posFromCellsInRange.vertical)
                    {
                        isHere = true;
                    }

                }

                if (!isHere)
                {
                    test.Report("Board.CellsInRange in pos: " + cell.GetBoardPosition().horizontal + cell.GetBoardPosition().vertical + " incorrect",
                       expectedResults[e].horizontal.ToString() + expectedResults[e].horizontal.ToString(),
                        posFromCellsInRange.horizontal.ToString() + posFromCellsInRange.vertical.ToString());
                    result = false;
                }
            }

            return result;
        }


    }
}
