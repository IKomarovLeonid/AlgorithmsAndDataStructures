using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
   

    

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

        public class LinkedList2
        {
            public Node head;
            public Node tail;

            public LinkedList2()
            {
                head = null;
                tail = null;
            }

            public void AddInTail(Node _item)
            {
                if (head == null)
                {
                    head = _item;
                    head.next = null;
                    head.prev = null;
                }
                else
                {
                    tail.next = _item;
                    _item.prev = tail;
                }
                tail = _item;
            }

            public Node Find(int _value)
            {
                Node node = head;
                while (node != null)
                {
                    if (node.value == _value)
                    {
                        return node;
                    }
                    node = node.next;
                }
                return null;
            }

            public List<Node> FindAll(int _value)
            {
                List<Node> nodes = new List<Node>();
                Node node = head;
                while (node != null)
                {
                    if (node.value == _value)
                    {
                        nodes.Add(node);
                    }
                    node = node.next;
                }
                return nodes;

            }

            public bool Remove(int _value)
            {
                if (head == null)
                {
                    return false;
                }
                if (head == tail)
                {
                    if (head.value == _value)
                    {
                        head = null;
                        tail = null;
                        return true;
                    }
                }
                if (head.value == _value)
                {
                    head.next.prev = null;
                    head = head.next;
                    return true;
                }
                if (tail.value == _value)
                {
                    tail = tail.prev;
                    tail.next = null;
                    return true;
                }
                Node node = Find(_value);
                if (node != null)
                {

                    Node temp = node.prev;
                    node.prev.next = node.next;
                    node.next.prev = temp;
                    return true;
                }

                return false;
            }

            public void RemoveAll(int _value)
            {
                int count = Count();
                while (count > 0)
                {
                    if (!Remove(_value))
                    {
                        break;
                    }
                    count--;

                }
                return;
            }

            public void Clear()
            {
                if (head == null)
                {
                    return;
                }
                if (head == tail)
                {
                    head = null;
                    return;
                }
                Node node = head;
                while (node != null)
                {
                    Remove(node.value);
                    node = node.next;
                }
            }

            public int Count()
            {
                if (head == null)
                {
                    return 0;
                }
                else
                {
                    int count = 0;
                    Node node = head;
                    while (node != null)
                    {
                        count++;
                        node = node.next;
                    }
                    return count;
                }
            }

            public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
            {
                if (head == null && _nodeAfter == null)
                {
                    head = _nodeToInsert;
                    tail = _nodeToInsert;
                    return;
                }
                if (head != null && _nodeAfter == null)
                {
                    AddInTail(_nodeToInsert);
                    return;
                }
                if (_nodeToInsert == null)
                {
                    return;
                }
                if (tail.value == _nodeAfter.value)
                {
                    AddInTail(_nodeToInsert);
                    return;
                }
                Node node = head;
                while (node != null)
                {
                    if (node.value == _nodeAfter.value)
                    {
                        Node A = node.next;
                        node.next = _nodeToInsert;
                        node.next.prev = _nodeToInsert;
                        _nodeToInsert.next = A;
                        _nodeToInsert.prev = node;
                        return;
                    }
                    node = node.next;
                }




            }

          
        }



    



}
