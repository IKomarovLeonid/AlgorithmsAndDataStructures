using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
 public class Vertex<T>
    {
        public T Value;
        public bool Hit;   // property of token, which is visited or not
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
        public Vertex<T>[] path;  // path for BFS algorithm 


        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
            path = new Vertex<T>[size];

        }

        public void AddVertex(T value)
        {
            // Add new Vertex into array of Vertexes with specific value
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
                            if (IsEdge(v, i)) RemoveEdge(v, i); // Remove all edges if v and i vertex contains edge
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
                //m_adjacency[v1,v2] and m_adjacency[v2,v1] now equals 0
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
            //m_adjacency[v1,v2] and m_adjacency[v2,v1] now equals 1
                if (IsEdge(v1, v2))
                {
                    m_adjacency[v1, v2] = 0;
                    m_adjacency[v2, v1] = 0;
                }
            }
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)  // DFS search
        {
        // return list of vertex which contains way from VFrom Vertex in vertex Array to VTo vertex in vertex Array 
            Reset(); // make all vertexes property Hit to false
            Stack<int> stack = new Stack<int>();
            List<Vertex<T>> list = new List<Vertex<T>>(); // rezult of searching 
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
            list.Clear(); // if we in here -> we don't find a way so return empty list;
            return list;
        }


        public void Reset()
        {
            for(int i=0;i<vertex.Length;i++)
            {
              if(vertex[i]!=null) vertex[i].Hit=false;
            }
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo) // BFS 
        {
            // return list of vertex which contains way from VFrom Vertex in vertex Array to VTo vertex in vertex Array
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
            // find shortest path 
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

      public List<Vertex<T>> WeakVertices() // find all vertexes which are not in triangular
                                            // not triangular vetrex is a vertex, which hasn't connected neighbours 
            {  
            int start = IsNotEmpty(); // check if is graph has any vertex
            if (start != -1) // graph has at least one vertex
            {
                
                List<Vertex<T>> list = new List<Vertex<T>>();
                Reset();
                Queue<int> trace = new Queue<int>();
                vertex[start].Hit = true;
                trace.Enqueue(start);
                while (trace.Count != 0)
                {
                    int current = trace.Dequeue();
                    if (!IsTriangle(current)) list.Add(vertex[current]);
                    for (int i = 0; i <= m_adjacency.GetUpperBound(0); i++)
                    {
                        if (m_adjacency[current, i] == 1 && vertex[i].Hit != true)
                        {
                            vertex[i].Hit = true;
                            trace.Enqueue(i);
                        }
                    }
                }
                return list;
            }
           

            return null;
        }

        public int IsNotEmpty() // check if graph contains vertex;
        {
            for(int i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] != null) return i;
            }
            return -1;
        }

        public bool IsTriangle(int index) 
        {
            LinkedList<int> temp = new LinkedList<int>();
            for(int i = 0; i < max_vertex; i++)
            {
                if (i == index) continue;
                if (IsEdge(i, index)) temp.AddLast(i);
            }

            foreach(int item in temp) // check every neighbours of neighbours vertex[index] vertex
            {
                var node = temp.First;
                while (node != null)
                { 
                    if (IsEdge(item, node.Value)) return true;
                    node = node.Next;
                }
            }

            return false;
        }



    }
}  
