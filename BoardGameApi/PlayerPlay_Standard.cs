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

            nextMovement = DidPlayerDoAnyMovementAvailable();

            if (nextMovement != null)
            {
                turnManager.NextStep();
            }


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
                return turnManager.GetGame().GetBoard().GetCell((Piece)actor);
            }
            else
            {
                return (Cell)actor;
            }
        }

        public List<T> ClearListBut<T>(T obj, List<T> list)
        {
            T aux = obj;

            list = new List<T>();

            list.Add(aux);

            return list;
        }

        public List<T> ClearList<T>(List<T> list)
        {
            list = new List<T>();

            return list;
        }

        public bool IsCellInAnyOrigin(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return true;
                }
            }

            return false;
        }
        
        public Action FindActionByDestinyCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                for (int j = 0; j < actionList[i].destinyCells.Count ; j++)
                {
                    if (actionList[i].destinyCells[j] == cell)
                    {
                        return actionList[i];
                    }
                }
            }

            return null;
        }

        public Action FindActionByOriginCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return actionList[i];
                }
            }

            return null;
        }



        public Action DidPlayerDoAnyMovementAvailable()
        {
            Cell destinyCell = null;

            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                Cell cell = TakeActorAsCell(inputs[i]);

                if (destinyCell == null)
                {
                    if (board.IsPlayerPiece(cell, currentPlayer))
                    {
                        if (IsCellInAnyOrigin(cell, movementsAvailable))
                        {
                            inputs =  ClearListBut(cell, inputs);
                            return null;
                        }
                        else
                        {
                            inputs = ClearList(inputs);
                            return null;
                        }
                    }
                    else
                    {
                        destinyCell = cell;
                    }
                }
                else
                {
                    if (board.IsPlayerPiece(cell, currentPlayer))
                    {
                        if (IsCellInAnyOrigin(cell, movementsAvailable))
                        {
                            Action action = FindActionByOriginCell(cell, movementsAvailable);

                            if (action.IsCellInDestiny(destinyCell))
                            { 
                                return action;
                            }
                            else
                            {
                                inputs = ClearListBut(cell, inputs);
                                return null;
                            }
                        }
                        else
                        {
                            inputs = ClearList(inputs);
                            return null;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            inputs = ClearList(inputs);
            return null;
        }



    }
}
