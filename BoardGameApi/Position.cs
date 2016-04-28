using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Position
    {
        public int horizontal;
        public int vertical;

        public Position(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }
    }
}
