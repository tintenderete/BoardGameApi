using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public interface IPieceFactory
    {
        Piece MakePiece(int pieceName);
    }
}
