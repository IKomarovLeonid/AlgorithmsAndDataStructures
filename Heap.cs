using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{
            public int[] HeapArray; 
            public int count;
            public Heap() { HeapArray = null; }

            public void MakeHeap(int[] a, int depth)
            {
                int newLen = (int)(Math.Pow(2, ++depth) - 1);
                HeapArray = new int[newLen];
                for (int i = 0; i < a.Length; i++) Add(a[i]);
            }

            public int GetMax() // Get Max from heap 
            {
               if (HeapArray == null || count == 0) return -1; // если куча пуста
                 int max = HeapArray[0];
                 HeapArray[0] = HeapArray[count - 1];
                 HeapArray[count - 1] = 0;
                 count--;
                 ReBuild(0); 
                 return max;
            }

            public bool Add(int key) // add key to heapArray
            {
                    if (count == HeapArray.Length) return false; 
                    int index = count;                           
                    HeapArray[index] = key;
                    int parent = (index - 1) / 2;              
                    while (index > 0 && parent >= 0)
                    {
                        if (HeapArray[index] > HeapArray[parent])
                        {
                            int temp = HeapArray[index];
                            HeapArray[index] = HeapArray[parent];
                            HeapArray[parent] = temp;
                        }

                        index = parent;
                        parent = (index - 1) / 2;
                    }
                    count++;

                    return true;
                
            }

       

             public  void ReBuild(int index)  // rebuild heap with specific algorithm
             {
                while (2 * index + 1 < count)
                {
                  int Left = 2 * index + 1;
                  int Right = 2 * index + 2;
                  int j = Left;

                    if (Right < count && HeapArray[Right] > HeapArray[Left]) j = Right;

                    if (HeapArray[index] <= HeapArray[j])
                    {
                      int temp = HeapArray[index];
                      HeapArray[index] = HeapArray[j];
                      HeapArray[j] = temp;
                    }

                   index = j;
                }
             }
		
	}
}  
