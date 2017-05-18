/*
 Author: Carlos Williamberg Farias Alves Pereira*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle8
{

    class Puzzle8
    {
        public int[,] target = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

        public List<State> aStar(State initial)
        {
            PriorityQueue priorityQueue = new PriorityQueue();
            List<int[,]> neighborStates = new List<int[,]>(4);
            State current;
            List<State> result = new List<State>();
            int moves = 0;

            current = initial;
            priorityQueue.Enqueue(moves, initial);

            while (! ArraysAreEqual( current.BoardPosition, target) )
            {
                moves++;
                current = priorityQueue.Dequeue() as State;
                result.Add(current);
                neighborStates.Add(moveLeft(current.BoardPosition));
                neighborStates.Add(moveRight(current.BoardPosition));
                neighborStates.Add(moveUp(current.BoardPosition));
                neighborStates.Add(moveDown(current.BoardPosition));
                foreach (var item in neighborStates)
                {
                    if (item != null && ( !ArraysAreEqual( item, current.BoardPosition))){
                        State state = new State(item, moves, current);
                        priorityQueue.Enqueue(Hamming(state), state);
                    }
                }
                neighborStates.Clear();
            }
            return result;
        }

        public int[,] readPuzzle()
        {
            int[,] result = new int[3, 3];
            string value; 
            int valueIndex = 0;

            Console.WriteLine("\tPuzzle 8 by Carlos Williamberg");
            Console.WriteLine("Enter the puzzle to solve. Ex: 103425786");
            Console.WriteLine("OBS: zero is the blank space");
            value = Console.ReadLine();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = value[valueIndex++] - 48;
            return result;
        }

        private int Hamming(State state)
        {
            var boardPosition = state.BoardPosition;
            int wrongLocations = 0;
            int correctValue = 1;
            for (int i = 0; i < boardPosition.GetLength(0); i++)
                for (int j = 0; j < boardPosition.GetLength(1); j++)
                {
                    if ((boardPosition[i, j] != 0) && (boardPosition[i, j] != correctValue))
                        wrongLocations++;
                    correctValue++;
                }
            return wrongLocations + state.Moves;
        }

        private int[,] moveLeft(int[,] vector)
        {
            Tuple<int, int> blackIndex = Tuple.Create<int, int>(-1, -1);
            int[,] result = vector.Clone() as int[,];

            for(int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == 0)
                        blackIndex = Tuple.Create<int, int>(i, j);
                }
            if (blackIndex.Item2 == 2){
                return null;
            }
            else
            {
                result[blackIndex.Item1, blackIndex.Item2] = result[blackIndex.Item1, blackIndex.Item2 + 1];
                result[blackIndex.Item1, blackIndex.Item2 + 1] = 0;
                return result;
            }
        }

        private int[,] moveRight(int[,] vector)
        {
            Tuple<int, int> blankIndex = Tuple.Create<int, int>(-1, -1);
            int[,] result = vector.Clone() as int[,];

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == 0)
                        blankIndex = Tuple.Create<int, int>(i, j);
                }
            if (blankIndex.Item2 == 0)
            {
                return null;
            }
            else
            {
                result[blankIndex.Item1, blankIndex.Item2] = result[blankIndex.Item1, blankIndex.Item2 - 1];
                result[blankIndex.Item1, blankIndex.Item2 - 1] = 0;
                return result;
            }
        }

        private int[,] moveUp(int[,] vector)
        {
            Tuple<int, int> blankIndex = Tuple.Create<int, int>(-1, -1);
            int[,] result = vector.Clone() as int[,];

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < vector.GetLength(1); j++)
                {
                    if (result[i, j] == 0)
                        blankIndex = Tuple.Create<int, int>(i, j);
                }
            if (blankIndex.Item1 == 2)
            {
                return null;
            }
            else
            {
                result[blankIndex.Item1, blankIndex.Item2] = vector[blankIndex.Item1 + 1, blankIndex.Item2];
                result[blankIndex.Item1 + 1, blankIndex.Item2] = 0;
                return result;
            }
        }

        private int[,] moveDown(int[,] vector)
        {
            Tuple<int, int> blankIndex = Tuple.Create<int, int>(-1, -1);
            int[,] result = vector.Clone() as int[,];

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == 0)
                        blankIndex = Tuple.Create<int, int>(i, j);
                }
            if (blankIndex.Item1 == 0)
            {
                return null;
            }
            else
            {
                result[blankIndex.Item1, blankIndex.Item2] = vector[blankIndex.Item1 - 1, blankIndex.Item2];
                result[blankIndex.Item1 - 1, blankIndex.Item2] = 0;
                return result;
            }
        }

        public void print(){
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (target[i, j] != 0)
                        System.Console.Write(target[i, j] + " ");
                    else
                        System.Console.Write("  ");
                }
                System.Console.WriteLine();
            }
        }

        public void print(int[,] vector)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (vector[i, j] != 0)
                        System.Console.Write(vector[i, j] + " ");
                    else
                        System.Console.Write("  ");
                }
                System.Console.WriteLine();
            }
        }

        //compare the two dimensional arrays and true if all the itens in the arrays are equals.
        private bool ArraysAreEqual(int[,] one, int[,] two)
        {
            for (int i = 0; i < one.GetLength(0); i++)
                for (int j = 0; j < one.GetLength(1); j++)
                    if (one[i, j] != two[i, j])
                        return false;
            return true;
        }

    }
}
