using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   class Deque<T>
        {
            public LinkedList<T> list;

            public Deque()
            {
                list = new LinkedList<T>();
            }

            public void AddFront(T item)
            {
                list.AddFirst(item); 
            }

            public void AddTail(T item)
            {
                list.AddLast(item);
            }

            public T RemoveFront()
            {
                if (Size() != 0)
                {
                    T data = list.First.Value;
                    list.RemoveFirst();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }

            public T RemoveTail()
            {
                if (Size() != 0)
                {
                    T data = list.Last.Value;
                    list.RemoveLast();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }

            public int Size()
            {
                return list.Count;
            }
        }

}
