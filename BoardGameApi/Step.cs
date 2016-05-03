using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    abstract class Step
    {
        private static TurnManager turnManager;

        public static void NewTurnManager(TurnManager newTurnManager)
        {
            turnManager = newTurnManager;
        }

        public abstract bool Update();

        protected List<Step> GetSteps()
        {
            return turnManager.GetSteps();
        }

        protected Step GetStep(int listPos)
        {
            return turnManager.GetStep(listPos);
        }
    }
}
