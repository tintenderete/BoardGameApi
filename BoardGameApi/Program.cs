using System;
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

            Test_BoardTableEditor test_BoardTableEditor = new Test_BoardTableEditor();
            Test_Board test_BoardEditor = new Test_Board();
            Test_PiecesToMove test_PiecesToMove = new Test_PiecesToMove();



            Console.ReadKey();
        }
        
    }
}
