using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Player
    {
        public enum colors {NoPiece, White, Black};

        private static List<Actor> inputs;

        private int color;

        public Player()
        {

        }

        public Player(int color)
        {
            this.color = color;
        }

        public int GetColor()
        {
            return color;
        }

        public void AddInput(Actor actor)
        {
            inputs.Add(actor);
        }

        public List<Actor> GetInputs()
        {
            return inputs;
        }

        public void SetInputs(List<Actor> newInputs)
        {
            inputs.Clear();
            foreach (Actor actor in newInputs)
            {
                inputs.Add(actor);
            }
        }

        public void SetZeroInputs()
        {
            inputs.Clear();
        }
    }
}
