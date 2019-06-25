using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
  public class Vertex   // class of simple graph vertex 
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;   // array for all vertex 
        public int[,] m_adjacency;  // matrix for edges 
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)  // add new wertex with value
        {
                for (int i = 0; i < vertex.Length; i++)
                {
                    if (vertex[i] == null)
                    {
                        vertex[i] = new Vertex(value);
                        break;
                    }
                }
           
        }

        public void RemoveVertex(int v)  // remove vertex from graph 
        {
            if(v>-1 && v < vertex.Length)
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

        public bool IsEdge(int v1, int v2) // check if edge is exist between v1 and v2 vertex 
        {
            if (v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1>-1 && v2>-1)
                return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
            else return false;
        }

        public void AddEdge(int v1, int v2) // add edge between v1 and v2 vertex 
        {
            if(v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1 > -1 && v2 > -1)
            {
                if (vertex[v1] != null && vertex[v2] != null && !IsEdge(v1, v2))
                {
                    m_adjacency[v1, v2] = 1;
                    m_adjacency[v2, v1] = 1;
                }
            }
           
        }

        public void RemoveEdge(int v1, int v2)  // remove edge between v1 and v2 vertex 
        {
            if(v1 < m_adjacency.Length && v2 < m_adjacency.Length && v1 > -1 && v2 > -1)
            {
                if (IsEdge(v1, v2))
                {
                    m_adjacency[v1, v2] = 0;
                    m_adjacency[v2, v1] = 0;
                }
            }
        }
    }
}  
