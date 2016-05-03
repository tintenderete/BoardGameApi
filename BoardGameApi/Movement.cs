using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class Movement
    {
        public Cell currentCell;
        public List<Cell> nextCells;

        public Movement(Cell currentCell)
        {
            this.currentCell = currentCell;
        }

        public Movement(Cell currentCell, List<Cell> nextCells)
        {
            this.currentCell = currentCell;
            this.nextCells = nextCells;
        }
    }
}
