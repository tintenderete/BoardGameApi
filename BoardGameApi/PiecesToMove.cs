using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class PiecesToMove
    {
        public List<Movement> movements;
        private Board board;
        private Player currentPlayer;

 
        public PiecesToMove(Board board, Player currentPlayer)
        {
            this.board = board;
            this.currentPlayer = currentPlayer;
            this.movements = new List<Movement>();
        }
        public PiecesToMove(Board board)
        {
            this.board = board;
        }
        public PiecesToMove()
        {
            
        }
        public void BasicMovementsAvailable()
        {
            movements.Clear();

            Cell[,] board = this.board.GetBoard();
            Piece pieceAux;

            Movement newMove;

            foreach (Cell cell in board )
            {
                pieceAux = cell.GetPiece();

                if (IsPlayerPiece(cell))
                {
                    newMove = new Movement(cell, NextCells(cell, cell.GetPiece().GetBasicMovement()));
                    movements.Add(newMove);
                }
    
            }
        }

        public bool IsPlayerPiece(Cell cell)
        {
            int currentPlayerColor = currentPlayer.GetColor();
            int pieceColor = cell.GetPiece().GetColor();

            if (currentPlayerColor == pieceColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<Cell> NextCells(Cell cell, List<Position> movementsSkill)
        {
            List<Cell> nextCells = new List<Cell>();    

            Position piecePosition = cell.GetBoardPosition();
            List<Position> pieceMovements = movementsSkill;


            Position nextPosition;
            Cell nextCell;

            foreach (Position movementSkill in pieceMovements)
            {
                nextPosition = NextPosition(piecePosition, movementSkill);

                if (IsPosOnTheBoard(nextPosition))
                {
                    nextCell = NextCell(nextPosition);
                    nextCells.Add(nextCell);
                }
            }

            return nextCells;
        }

        public Position NextPosition(Position currentPos, Position movementSkill)
        {
            Position newPosition;

            newPosition = new Position(
                    currentPos.horizontal + movementSkill.horizontal,
                    currentPos.vertical + movementSkill.vertical
                    );

            return newPosition;
        }

       



        public bool IsPosOnTheBoard(Position position)
        {
            int sizeV = board.GetSize().vertical;
            int sizeH =  board.GetSize().horizontal;

            if (position.vertical < 0 || position.vertical > sizeV)
            {
                return false;
            }

            if (position.horizontal < 0 || position.horizontal > sizeH)
            {
                return false;
            }


            return true;
        }

        private Cell NextCell(Position newPos)
        {

            Cell newCell;

            newCell = board.GetCell(newPos.horizontal, newPos.vertical);

            return newCell;
        }




    }
}
