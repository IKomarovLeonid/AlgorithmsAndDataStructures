using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
  public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int temp = 1;
            while (depth > -1)
            {
                temp = temp * 2;
                depth--;
            }
            int tree_size = temp-1; 
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            if (Tree[0] == null) return -0;
            else
            {
                int currentIndex = 0;
                while (currentIndex < Tree.Length)
                {
                    if (Tree[currentIndex] == null) return -currentIndex;
                    if (Tree[currentIndex] == key) return currentIndex;
                    if (key < Tree[currentIndex])
                    {
                        currentIndex = 2 * currentIndex + 1;
                    }
                    else
                    {
                        currentIndex = 2 * currentIndex + 2;
                    }
                }
                return null;
            }
            

            
        }

        public int AddKey(int key)
        {
            if (Tree[0] == null)
            {
                Tree[0] = key;
                return 0;
            }
            else
            {
                if (Tree[0] == key) return 0;
                else
                {
                    int currentIndex = 0;
                    while (Tree[currentIndex] != null)
                    {
                        if (key > Tree[currentIndex])
                        {
                            currentIndex = 2 * currentIndex + 2;
                        }
                        else
                        {
                            currentIndex = 2 * currentIndex + 1;
                        }
                        if (currentIndex > Tree.Length - 1) break;
                        if (Tree[currentIndex] == null)
                        {
                            Tree[currentIndex] = key;
                            return currentIndex;
                        }

                        if (Tree[currentIndex] == key) return currentIndex;
                    }
                    return -1;
                }
                
            }
           
            // индекс добавленного/существующего ключа или -1 если не удалось
        }

    }
}  
