using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class Piece: Actor
    {
        public enum colors {NoPiece, White, Black };
        protected int color;
        protected List<int[]> basicMovement;

        public Piece()
        {
            
        }

        public Piece(int color, List<int[]> basicMovement)
        {
            this.color = color;
            this.basicMovement = basicMovement;
        }

        public int GetColor()
        {
            return color;
        }

        public List<int[]> GetBasicMovement()
        {
            return basicMovement;
        }

        
    }
}
