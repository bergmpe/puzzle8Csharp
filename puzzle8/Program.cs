/*
 Author: Carlos Williamberg Farias Alves Pereira*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] boardToSolve = new int[,] { { 1, 0, 3 },
                                               { 4, 2, 5 },
                                               { 7, 8, 6 } };
            List<State> result;
            Puzzle8 puzzle = new Puzzle8();
            State initialState = new State(puzzle.readPuzzle(), 0, null);

            
            result = puzzle.aStar(initialState);
            foreach (var item in result)
            {
                puzzle.print(item.BoardPosition);
                System.Console.WriteLine();
            }
            System.Console.ReadKey();
        }
    }
}
