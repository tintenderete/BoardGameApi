using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Action
    {
        public Cell originCell;
        public List<Cell> destinyCells;

        public Action(Cell currentCell)
        {
            this.originCell = currentCell;
        }

        public Action(Cell currentCell, List<Cell> nextCells)
        {
            this.originCell = currentCell;
            this.destinyCells = nextCells;
        }

        public void NoPlayerCellsInDestiny(Player player)
        {
            int playerColor = player.GetColor();
            int pieceColor;

            List<Cell> cellsToRemove = new List<Cell>();

            for(int i = 0; i < destinyCells.Count; i++)
            {
                pieceColor = destinyCells[i].GetPiece().GetColor();
                
                if (pieceColor == playerColor)
                {
                    cellsToRemove.Add(destinyCells[i]);
                }
            }

            for (int i = 0; i < cellsToRemove.Count; i++)
            {
                destinyCells.Remove(cellsToRemove[i]);
            }

    }
}
