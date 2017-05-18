/*
 Author: Carlos Williamberg Farias Alves Pereira*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle8
{
    class State
    {
        private int[,] boardPosition;
        public int Moves{ get; set;}
        private State prevState;

        public int[,] BoardPosition
        {
            get { return boardPosition; }
        }

        public State(int[,] boardPosition, int moves, State prevState)
        {
            this.boardPosition = boardPosition;
            this.Moves = moves;
            this.prevState = prevState;
        }
    }
}
