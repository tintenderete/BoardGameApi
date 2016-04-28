using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public abstract class Actor
    {
        static int idCount = 0;

        public enum types { Cell, Piece };

        protected int type;

        private int id;

        public Actor()
        {
            id = idCount;
            idCount++;
        }

        public int Get_type()
        {
            return type;
        }

        public int GetId()
        {
            return id;
        }

    }
    
}
