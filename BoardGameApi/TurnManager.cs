using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class TurnManager
    {
        private List<Step> steps;
        private int currentStep;

        public TurnManager()
        {
            this.currentStep = 0;
            steps = new List<Step>();
            Step.NewTurnManager(this);
        }

        public void AddStep(Step step)
        {
            steps.Add(step);
        }

        public void Update()
        {
            if (steps[currentStep].Update())
            {
                NextStep();
            }
        }

        public List<Step> GetSteps()
        {
            return this.steps;
        }

        public Step GetStep(int listPos)
        {
            return steps[listPos];
        }

        private void NextStep()
        {
            currentStep++;
            if (currentStep > steps.Capacity)
            {
                currentStep = 0;
            }
        }
    }
}
