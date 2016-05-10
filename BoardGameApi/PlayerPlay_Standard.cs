using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PlayerPlay_Standard: IStep
    {
        public Timer timer;
        public List<Action> movementsAvailable;
        public Player currentPlayer;
        public List<Actor> inputs;
        public Action nextMovement;

        private Board board;
        private TurnManager turnManager;

        public PlayerPlay_Standard(TurnManager turnManager)
        {
            this.timer = new Timer(30);
            this.movementsAvailable = new List<Action>();
            this.currentPlayer = new Player();
            this.inputs = new List<Actor>();
            this.nextMovement = new Action(new Cell(), new List<Cell>());
            this.board = new Board();
            this.turnManager = turnManager;
        }

        public void UpdateStep(TurnManager turnManager)
        {
            RefreshPlayerInputs();

            



        }

        public void RefreshPlayerInputs()
        {
            inputs = currentPlayer.GetInputs();
        }

        public bool IsActorCell(Actor actor)
        {
            if (actor.Get_type() == (int)Actor.types.Cell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsActorPiece(Actor actor)
        {
            if (actor.Get_type() == (int)Actor.types.Piece)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public Cell TakeActorAsCell(Actor actor)
        {
            if (IsActorPiece(actor))
            {
                return turnManager.GetGame().GetBoard().GetCell((Piece)inputs[i]);
            }
            else
            {
                return (Cell)inputs[i];
            }
        }

        
        

        

       

    }
}
