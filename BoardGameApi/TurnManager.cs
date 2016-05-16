using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class TurnManager
    {
        private List<IStep> steps;
        private int currentStep;
        private Game game;

        public TurnManager(Game newGame)
        {
            this.currentStep = 0;
            steps = new List<IStep>();
            game = newGame;
        }

        public TurnManager()
        {
            this.currentStep = 0;
            steps = new List<IStep>();
            game = null;
        }

        public void AddStep(IStep step)
        {
            steps.Add(step);
        }

        public void Update()
        {
            steps[currentStep].UpdateStep(this);  
        }

        public List<IStep> GetSteps()
        {
            return this.steps;
        }

        public IStep GetStep(int listPos)
        {
            return steps[listPos];
        }

        public void NextStep()
        {
            currentStep++;
            if (currentStep >= steps.Count)
            {
                currentStep = 0;
            }
        }

        public void NextStep(int nextStep)
        {
            currentStep = nextStep;
        }

        public int GetCurrentStep()
        {
            return currentStep;
        }

        public Game GetGame()
        {
            return game;
        }

        public void SetGame(Game game)
        {
             this.game = game ;
        }
    }
}
