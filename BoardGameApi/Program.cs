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


            Step_Test step_test = new Step_Test();

            if (!step_test.TurnManagerLength_test())
            {
                Console.WriteLine("Turn Manager is not update");
            }

            Console.WriteLine("Test finished");
            Console.ReadKey();
        }
        
    }
}
