﻿using System;
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
        protected List<Position> basicMovement;

        public Piece()
        {
            this.type = (int)Actor.types.Piece;
        }

        public Piece(int color, List<Position> basicMovement)
        {
            this.color = color;
            this.basicMovement = basicMovement;
            this.type = (int)Actor.types.Piece;
        }

        public int GetColor()
        {
            return color;
        }

        public List<Position> GetBasicMovement()
        {
            return basicMovement;
        }

        
    }
}
