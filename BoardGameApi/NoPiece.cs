using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class NoPiece: Piece
    {
        
        public NoPiece()
        {
            color = (int)Piece.colors.NoPiece; 
        }
    }
}
