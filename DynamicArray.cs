using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

        public class DynArray<T>
        {
            public T[] array;
            public int count;
            public int capacity;

            public DynArray()
            {
                count = 0;
                MakeArray(16);
            }

            public void MakeArray(int new_capacity)
            {

                if (array == null)
                {
                    array = new T[new_capacity];
                    capacity = new_capacity;
                    return;
                }
                else
                {
                    if (new_capacity > capacity)
                    {
                        T[] new_array = new T[new_capacity];
                        for (int i = 0; i < count; i++)
                        {
                            new_array[i] = array[i];
                        }
                        capacity = new_capacity;
                        array = new_array;
                    }
                    else
                    {
                        T[] new_array = new T[new_capacity];
                        for (int i = 0; i < new_capacity; i++)
                        {
                            new_array[i] = array[i];
                        }
                        capacity = new_capacity;
                        array = new_array;
                    }
                }



            }

            public T GetItem(int index)
            {
                try
                {
                    T output = array[index];
                    return output;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return default(T);
                }

            }

            public void Append(T itm)
            {
                if (count == capacity)
                {
                    MakeArray(2 * capacity);

                }
                array[count] = itm;
                count++;
                return;

            }

            public void Insert(T itm, int index)
            {

               
                if (index > count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index == count)
                {
                    Append(itm);
                    return;
                }
                if (count == capacity)
                {
                    MakeArray(2 * capacity);

                }
               
                    for (int i = array.Length - 1; i > index; i--)
                    {
                        array[i] = array[i - 1];
                    }
                    array[index] = itm;
                    count++;

                    return;
                



            }

            public void Remove(int index)
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                } 
                else
                {
                    if (index == count - 1)
                    {
                        count--;
                    }
                    else
                    {
                        for (int i = index; i < count - 1; i++)
                        {
                            array[i] = array[i + 1];
                        }
                        count--;
                    }

                    double k = (double)capacity / count;
                    if (k > 2)
                    {
                        int m = (int)(capacity / 1.5);
                        if (m < 16)
                        {
                            MakeArray(16);
                            return;
                        }
                        else
                        {
                            MakeArray(m);
                            return;
                        }
                    }
                    else return;

                }
            }
        }
}
