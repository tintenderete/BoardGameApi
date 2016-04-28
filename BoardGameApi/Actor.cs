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
<<<<<<< HEAD
        public static int GetCount() { return idCount; }
        public static void ResetCount() {idCount = 0; }

=======
        static void ResetIdCount() { idCount = 0; }
>>>>>>> refs/remotes/origin/sV-1.0
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
