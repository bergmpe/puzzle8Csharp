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
            Puzzle8 puzzle = new Puzzle8();
            while (true)
            {
                puzzle.solve( puzzle.readPuzzle() );
            }

            System.Console.ReadKey();
        }
    }
}
