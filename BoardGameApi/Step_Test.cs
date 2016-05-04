using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Step_Test
    {

        Step step1;
        Step step2;
        TurnManager turnManager;

        public Step_Test()
        {
            step1 = new PiecesToMove();
            step2 = new PiecesToMove();
            turnManager = new TurnManager();
        }

        public bool TurnManagerLength_test()
        {
            turnManager.AddStep(step1);

            if(step1.GetSteps().Count != 1 )
            {
                Console.WriteLine("Lenght no 1");
                return false;
            }

            turnManager.AddStep(step2);

            if (step1.GetSteps().Count != 2)
            {
                Console.WriteLine("Lenght no 2");
                return false;
            }
            
            return true;
        }
        
            
    }
}
