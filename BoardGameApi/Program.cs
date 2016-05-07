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
            PiecesToMove_Standard_Test piecesToMove = new PiecesToMove_Standard_Test();

            if (piecesToMove.IsMovementsCorrect())
            {
                Console.WriteLine("Is movement correct success");
            }

            Console.WriteLine("Test finishes");
            Console.ReadKey();

        }
        
    }
}
