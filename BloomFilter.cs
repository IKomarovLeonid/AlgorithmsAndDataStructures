using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
            public int filter_len;
            public int[] array;

            public BloomFilter(int f_len)
            {
                filter_len = f_len;
                array = new int[f_len];
            }

            // хэш-функции
            public int Hash1(string str1)
            {
                int hash = 0;
                for (int i = 0; i < str1.Length; i++)
                {
                    hash += str1[i];
                    hash += (hash << 10);
                    hash ^= (hash << 6);
                }

                int index = Math.Abs(hash % (filter_len + 1));
                if (index > filter_len - 1)
                {
                    while (index > (filter_len - 2))
                    {
                        index--;
                    }
                }

                return index;
            }

            public int Hash2(string str1)
            {
                int hash = 223;
                foreach (int c in str1.ToCharArray())
                {
                    hash = (((hash << 3) + hash) + c);
                }
                int index = Math.Abs(hash % (filter_len + 1));
                if (index > filter_len - 1)
                {
                    while (index > (filter_len - 2))
                    {
                        index--;
                    }
                }
                return index;
            }

            public void Add(string str1)
            {
                int index1 = Hash1(str1);
                int index2 = Hash2(str1);
                if (index1 == index2) array[index1] = 1;
                else
                {
                    array[index1] = 1;
                    array[index2] = 1;
                }
              
            }

            public bool IsValue(string str1)
            {
                int index1 = Hash1(str1);
                int index2 = Hash2(str1);
                if (array[index1] == 1 && array[index2] == 1) return true;
                return false;
            }
   }
}
