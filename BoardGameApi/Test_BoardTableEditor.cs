using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Test_BoardTableEditor
    {

        TestRunner test = new TestRunner();


        public Test_BoardTableEditor()
        {
            test.RunTest(Test1_A(), " Test1_A");
            test.RunTest(Test1_B(), " Test1_B");
            test.RunTest(Test1_B(), " Test1_C");
            test.RunTest(Test1_D(), " Test1_D");
            test.RunTest(Test1_E(), " Test1_E");
        }


        bool Test1_A()
        {
            bool testResult = true;
            Board board;
            BoardTableEditor editor = new BoardTableEditor(8,8, new StandardPieceFactory());

            for (int i = 0; i < 8; i++)
            {
                editor.SetPointerInLine(i);

                editor.PushPiece( 8, (int)StandardPieceFactory.names.standard_White );
            }

            board = editor.GetBoard();

            int color;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    color = board.GetCell(j, i).GetPiece().GetColor();
                    if (color != (int)Piece.colors.White)
                    {
                        test.Report("Color of piece", (int)Piece.colors.White, color);
                      
                        testResult = false;
                    }
                }
            }

            return testResult;
        }

        bool Test1_B()
        {
            bool testResult = true;
            Board board;
            BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

            for (int i = 0; i < 8; i++)
            {
                editor.SetPointerInLine(i);

                editor.PushPiece(8, (int)StandardPieceFactory.names.standard_Black);
            }

            board = editor.GetBoard();

            int color;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    color = board.GetCell(j, i).GetPiece().GetColor();
                    if (color != (int)Piece.colors.Black)
                    {
                        test.Report("Color of piece", (int)Piece.colors.Black, color);

                        testResult = false;
                    }
                }
            }

            return testResult;
        }

        bool Test1_C()
        {
            bool testResult = true;
            Board board;
            BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

            for (int i = 0; i < 8; i++)
            {
                editor.SetPointerInLine(i);

                if (i % 2 == 0)
                {
                    editor.PushPiece(8, (int)StandardPieceFactory.names.standard_Black);
                }
                else
                {
                    editor.PushPiece(8, (int)StandardPieceFactory.names.standard_White);
                }

                
            }

            board = editor.GetBoard();

            int color;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    color = board.GetCell(j, i).GetPiece().GetColor();

                    if (i % 2 == 0)
                    {
                        if (color != (int)Piece.colors.Black)
                        {
                            test.Report("Color of piece", (int)Piece.colors.Black, color);

                            testResult = false;
                        }
                    }
                    else
                    {
                        if (color != (int)Piece.colors.White)
                        {
                            test.Report("Color of piece", (int)Piece.colors.White, color);

                            testResult = false;
                        }
                    }
                    
                }
            }

            return testResult;
        }

        bool Test1_D()
        {
            bool testResult = true;
            Board board;
            BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

            for (int i = 0; i < 8; i++)
            {
                editor.SetPointerInLine(i);

                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == 0)
                    {
                        editor.PushPiece(1, (int)StandardPieceFactory.names.standard_White);
                    }
                    else
                    {
                        editor.PushPiece(1, (int)StandardPieceFactory.names.standard_Black);
                    }
                }

            }

            board = editor.GetBoard();

            int color;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    color = board.GetCell(j, i).GetPiece().GetColor();

                    if (j % 2 == 0)
                    {
                        if (color != (int)Piece.colors.White)
                        {
                            test.Report("Color of piece", (int)Piece.colors.White, color);

                            testResult = false;
                        }
                    }
                    else
                    {
                        if (color != (int)Piece.colors.Black)
                        {
                            test.Report("Color of piece", (int)Piece.colors.Black, color);

                            testResult = false;
                        }
                    }

                }
            }

            return testResult;
        }

        bool Test1_E()
        {
            bool testResult = true;
            Board board;
            BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

            for (int i = 0; i < 8; i++)
            {
                editor.SetPointerInLine(i);

                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 != 0)
                    {
                        editor.PushPiece(1, (int)StandardPieceFactory.names.standard_White);
                    }
                    else
                    {
                        editor.PushPiece(1, (int)StandardPieceFactory.names.standard_Black);
                    }
                }

            }

            board = editor.GetBoard();

            int color;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    color = board.GetCell(j, i).GetPiece().GetColor();

                    if (j % 2 != 0)
                    {
                        if (color != (int)Piece.colors.White)
                        {
                            test.Report("Color of piece", (int)Piece.colors.White, color);

                            testResult = false;
                        }
                    }
                    else
                    {
                        if (color != (int)Piece.colors.Black)
                        {
                            test.Report("Color of piece", (int)Piece.colors.Black, color);

                            testResult = false;
                        }
                    }

                }
            }

            return testResult;
        }

    }
}
