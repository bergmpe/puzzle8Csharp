/*
 Author: Carlos Williamberg Farias Alves Pereira*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace puzzle8
{
    class PriorityQueue
    {
        private SortedList<int, Queue> storage;
        public int Length{get; private set;}

        public PriorityQueue()
        {
            storage = new SortedList<int, Queue>();
            Length = 0;
        }

        private bool IsEmpty()
        {
            return Length == 0;
        }


        public void Enqueue(int priority, object obj)
        {
            if (!storage.ContainsKey (priority)) {
                storage.Add (priority, new Queue ());
              }
            storage[priority].Enqueue (obj);
            Length++;
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Please check that priorityQueue is not empty before dequeing");
            }
            else
                foreach (Queue q in storage.Values)
                {
                    // we use a sorted list
                    if (q.Count > 0)
                    {
                        Length--;
                        return q.Dequeue();
                    }
                }
            return null; // not supposed to reach here.
        }
    }
}
