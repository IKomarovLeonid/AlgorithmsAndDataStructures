using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
 public class Vertex<T>
    {
        public T Value;
        public bool Hit;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;
        public Vertex<T>[] path;


        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
            path = new Vertex<T>[size];

        }

        public void AddVertex(T value)
        {
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
            for (int i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex<T>(value);
                    break;
                }
            }

        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            if (v > -1 && v < vertex.Length)
            {
                if (vertex[v] != null)
                {
                    int index = v;
                    for (int i = 0; i < vertex.Length; i++)
                    {
                        if (i == v) continue;
                        else
                        {
                            if (IsEdge(v, i)) RemoveEdge(v, i);
                        }
                    }
                    vertex[v] = null;
                }
            }

        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1 > -1 && v2 > -1)
                return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
            else return false;
        }

        public void AddEdge(int v1, int v2)
        {
            if (v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1 > -1 && v2 > -1)
            {
                if (vertex[v1] != null && vertex[v2] != null && !IsEdge(v1, v2))
                {
                    m_adjacency[v1, v2] = 1;
                    m_adjacency[v2, v1] = 1;
                }
            }

        }

        public void RemoveEdge(int v1, int v2)
        {
            if (v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1 > -1 && v2 > -1)
            {
                if (IsEdge(v1, v2))
                {
                    m_adjacency[v1, v2] = 0;
                    m_adjacency[v2, v1] = 0;
                }
            }
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            Reset();
            Stack<int> stack = new Stack<int>();
            List<Vertex<T>> list = new List<Vertex<T>>();
            int temp = VFrom;
            vertex[temp].Hit = true;
            stack.Push(temp);
            while (stack.Count != 0)
            {
                int value = stack.Pop();
                list.Add(vertex[value]);
                for (int i = 0; i < vertex.Length; i++)
                {
                    if (m_adjacency[i, value] == 1 && i == VTo)
                    {
                        list.Add(vertex[i]);
                        return list;
                    }

                    if (m_adjacency[value, i] == 1 && !vertex[i].Hit)
                    {
                        stack.Push(i);
                        vertex[i].Hit = true;
                    }

                }
            }
            list.Clear();
            return list;
        }


        public void Reset()
        {
            foreach (var item in vertex) item.Hit = false;
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            // узлы задаются позициями в списке vertex.
            // возвращает список узлов -- путь из VFrom в VTo
            // или пустой список, если пути нету
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i].Hit = false;
                path[i] = null;
            }
            
            Queue<int> trace = new Queue<int>();
            int current = VFrom;
            vertex[current].Hit = true;
            trace.Enqueue(current);
            while (trace.Count != 0)
            {
                current = trace.Dequeue();
                for (int i = 0; i <= m_adjacency.GetUpperBound(0); i++)
                {
                    if (m_adjacency[current, i] == 1 && vertex[i].Hit != true)
                    {
                        vertex[i].Hit = true;
                        path[i] = vertex[current];
                        trace.Enqueue(i);
                    }
                }
            }
            // поиск кратчайшего пути
            List<Vertex<T>> result = new List<Vertex<T>>();
            current = VTo;
            while (path[current] != null)
            {
                result.Add(vertex[current]);
                current = Array.IndexOf(vertex, path[current]);
            }
            result.Add(vertex[VFrom]);
            result.Reverse();
            if (result.Count == 1) result.Clear(); 
            return result;
        }





    }
}  
