using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class Node<T>
        {
            public T value;
            public Node<T> next, prev;

            public Node(T _value)
            {
                value = _value;
                next = null;
                prev = null;
            }
        }

        public class OrderedList<T>
        {
            public Node<T> head, tail;
            private bool _ascending;

            public OrderedList(bool asc)
            {
                head = null;
                tail = null;
                _ascending = asc;
            }

            public int Compare(T v1, T v2)
            {
                int result = 0;
                if (typeof(T) == typeof(String))
                {
                    result = String.Compare(Convert.ToString(v1), Convert.ToString(v2));
                    return result;
                }
                else
                {
                    long x = Convert.ToInt64(v1);
                    long y = Convert.ToInt64(v2);
                    if (x < y)
                    {
                        return -1;
                    }
                    else
                    {
                        if (x > y)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }


                // -1 если v1 < v2
                // 0 если v1 == v2
                // +1 если v1 > v2
            }

            public void Add(T value)
            {
                Node<T> newNode = new Node<T>(value);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;

                }
                else
                {
                    if (_ascending)
                    {
                        if (Compare(newNode.value, head.value) != 1)
                        {
                            newNode.next = head;
                            head.prev = newNode;
                            head = newNode;
                        }
                        else
                        {
                            if (Compare(newNode.value, tail.value) != -1)
                            {
                                tail.next = newNode;
                                newNode.prev = tail;
                                tail = newNode;
                            }
                            else
                            {
                                Node<T> node = head;
                                while (node != null)
                                {
                                    int temp = Compare(node.value, value);
                                    if (temp != -1)
                                    {
                                        newNode.next = node;
                                        newNode.prev = node.prev;
                                        node.prev.next = newNode;
                                        node.prev = newNode;
                                        break;

                                    }
                                    node = node.next;
                                }
                            }
                        }

                    }
                    else
                    {
                        if (Compare(newNode.value, head.value) != -1)
                        {
                            newNode.next = head;
                            head.prev = newNode;
                            head = newNode;
                        }
                        else
                        {
                            if (Compare(newNode.value, tail.value) != 1)
                            {
                                tail.next = newNode;
                                newNode.prev = tail;
                                tail = newNode;
                            }
                            else
                            {
                                Node<T> node = head;
                                while (node != null)
                                {
                                    int temp = Compare(node.value, value);
                                    if (temp != 1)
                                    {
                                        newNode.next = node;
                                        newNode.prev = node.prev;
                                        node.prev.next = newNode;
                                        node.prev = newNode;
                                        break;

                                    }
                                    node = node.next;
                                }
                            }
                        }




                    }
                }

            }

            public Node<T> Find(T val)
            {
                Node<T> output = null;
                if (head == null)
                {
                    return null;
                }
                else
                {
                    if (_ascending)
                    {
                        Node<T> node = head;
                        while (node != null && Compare(node.value, val) != 1)
                        {
                            if (node.value.Equals(val))
                            {
                                output = node;
                                break;
                            }
                            node = node.next;
                        }
                    }
                    else
                    {
                        Node<T> node = head;
                        while (node != null && Compare(node.value, val) != -1)
                        {
                            if (node.value.Equals(val))
                            {
                                output = node;
                                break;
                            }
                            node = node.next;
                        }
                    }
                    return output;
                }


            }

            public void Delete(T val)
            {
                Node<T> node = Find(val);
                if (node != null)
                {
                    if (node.prev == null && node.next == null)
                    {
                        Clear(_ascending);
                    }
                    else
                    {
                        if (node.prev == null && node.next != null)
                        {
                            head = node.next;
                            head.prev = null;

                        }
                        else
                        {
                            if (node.prev != null && node.next == null)
                            {
                                tail = node.prev;
                                node.prev.next = null;

                            }
                            else
                            {
                                node.prev.next = node.next;
                                node.next.prev = node.prev;
                            }
                        }
                    }
                }


            }

            public void Clear(bool asc)
            {
                head = null;
                tail = null;
                _ascending = asc;
                // здесь будет ваш код
            }

            public int Count()
            {
                int result = 0;
                Node<T> node = head;
                while (node != null)
                {
                    result++;
                    node = node.next;
                }
                return result;
            }

            List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                                   // списка в виде стандартного списка
            {
                List<Node<T>> r = new List<Node<T>>();
                Node<T> node = head;
                while (node != null)
                {
                    r.Add(node);
                    node = node.next;
                }
                return r;
            }
        }
 
}
