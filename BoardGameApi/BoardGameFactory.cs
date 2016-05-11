using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    class BoardGameFactory
    {
        public enum names { Standard };

        public BoardGameFactory()
        {
        }

        public Board MakeBoard(int boardName)
        {
            if (boardName == (int)names.Standard)
            {
                return new StandardBoardGame();
            }

            return new Board();
        }
        

    }
            
}
