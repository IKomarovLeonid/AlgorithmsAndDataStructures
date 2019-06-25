using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
   public class BSTNode<T>
    {
        public int NodeKey; // Node key
        public T NodeValue; // Node value
        public BSTNode<T> Parent; // Parent or null for root 
        public BSTNode<T> LeftChild; 
        public BSTNode<T> RightChild; 

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // Temporary result of search 
    public class BSTFind<T>
    {
        // if we don't find a node with key or tree has only root: null
        public BSTNode<T> Node;

        // if we found key : true 
        public bool NodeHasKey;

        // if new Node will join to leftchild position: true
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T> // Binary search Tree class 
    {
        BSTNode<T> Root;
        public int amount;

        public BST(BSTNode<T> node)
        {
            if (node != null)
            {
                Root = node;
                amount++;
            }
        }

        public BSTFind<T> FindNodeByKey(int key) // find Node in tree with key
        {
            if (Root == null)
            {
                BSTFind<T> rezult = new BSTFind<T>();
                rezult.Node = null;
                rezult.NodeHasKey = false;
                return rezult;

            }
            else
            {
                if (Root.LeftChild == null && Root.RightChild == null)
                {
                    if (key != Root.NodeKey)
                    {
                        if (key < Root.NodeKey)
                        {
                            BSTFind<T> node = new BSTFind<T>();
                            node.Node = null;
                            node.NodeHasKey = false;
                            node.ToLeft = true;
                            return node;
                        }
                        else
                        {
                            BSTFind<T> node = new BSTFind<T>();
                            node.Node = null;
                            node.NodeHasKey = false;
                            node.ToLeft = false;
                            return node;
                        }
                    }
                    else
                    {
                        BSTFind<T> node = new BSTFind<T>();
                        node.Node = Root;
                        node.NodeHasKey = true;
                        node.ToLeft = false;
                        return node;
                    }

                }
                else
                {
                    BSTFind<T> node = Find(Root, key);
                    return node;
                }

            }

        }

        public BSTFind<T> Find(BSTNode<T> node, int key) // find node by key 
        {
            if (node.NodeKey == key)
            {
                BSTFind<T> rez = new BSTFind<T>();
                rez.Node = node;
                rez.NodeHasKey = true;
                rez.ToLeft = false;
                return rez;
            }
            else
            {
                if (key > node.NodeKey)
                {
                    if (node.RightChild == null)
                    {
                        BSTFind<T> rez = new BSTFind<T>();
                        rez.Node = node;
                        rez.NodeHasKey = false;
                        rez.ToLeft = false;
                        return rez;
                    }
                    else
                    {
                        BSTFind<T> rez = Find(node.RightChild, key);
                        return rez;
                    }
                }
                else
                {
                    if (node.LeftChild == null)
                    {
                        BSTFind<T> rez = new BSTFind<T>();
                        rez.Node = node;
                        rez.NodeHasKey = false;
                        rez.ToLeft = true;
                        return rez;
                    }
                    else
                    {
                        BSTFind<T> rez = Find(node.LeftChild, key);
                        return rez;
                    }
                }

            }
        }

        public bool AddKeyValue(int key, T val) // add key to tree 
        {
            if (Root == null)
            {
                BSTNode<T> node = new BSTNode<T>(key, val, null);
                Root = node;
                amount++;
                return true;
            }
            else
            {
                BSTFind<T> node = FindNodeByKey(key);
                if (node.NodeHasKey) return false;
                else
                {
                    Add(Root, key, val);
                    amount++;
                    return true;
                }

            }

        }

        public void Add(BSTNode<T> node, int key, T val) // recursive add key to tree 
        {
            if (key < node.NodeKey)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new BSTNode<T>(key, val, node);
                    return;
                }
                else
                {
                    Add(node.LeftChild, key, val);
                }
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new BSTNode<T>(key, val, node);

                    return;
                }
                else
                {
                    Add(node.RightChild, key, val);
                }
            }
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax) // find min/max in tree from someNode
        {
            if (FromNode == null) return null;
            else
            {
                BSTFind<T> node = FindNodeByKey(FromNode.NodeKey);
                if (node.Node == null)
                {
                    return Root;
                }
                else
                {
                    if (FindMax)
                    {
                        if (FromNode.RightChild == null) return FromNode;
                        else
                        {
                            BSTNode<T> rez = FinMinMax(FromNode.RightChild, true);
                            return rez;
                        }
                    }
                    else
                    {
                        if (FromNode.LeftChild == null) return FromNode;
                        else
                        {
                            BSTNode<T> rez = FinMinMax(FromNode.LeftChild, false);
                            return rez;
                        }
                    }

                }

            }


        }



        public bool DeleteNodeByKey(int key) // delete Node from tree 
        {
            BSTFind<T> findnode = FindNodeByKey(key);
            if (!findnode.NodeHasKey) return false;
            else
            {
                if (findnode.Node.LeftChild == null && findnode.Node.RightChild == null) // когда лист
                {
                    if (findnode.Node.Parent == null)
                    {
                        findnode.Node = null;
                        Root = null;
                        amount--;
                        return true;
                    }
                    else
                    {
                        if (findnode.Node.NodeKey < findnode.Node.Parent.NodeKey)
                        {
                            findnode.Node.Parent.LeftChild = null;
                            amount--;
                            return true;
                        }
                        else
                        {
                            findnode.Node.Parent.RightChild = null;
                            amount--;
                            return true;
                        }
                    }

                }
                else
                {
                    if (findnode.Node.LeftChild == null && findnode.Node.RightChild != null) // когда только правый потомок
                    {
                        if (findnode.Node.Parent == null)
                        {
                            Root = Root.RightChild;
                            amount--;
                            return true;
                        }
                        else
                        {
                            if (findnode.Node.NodeKey < findnode.Node.Parent.NodeKey)
                            {
                                findnode.Node.RightChild.Parent = findnode.Node.Parent;
                                findnode.Node.Parent.LeftChild = findnode.Node.RightChild;
                                amount--;
                                return true;
                            }
                            else
                            {
                                findnode.Node.RightChild.Parent = findnode.Node.Parent;
                                findnode.Node.Parent.RightChild = findnode.Node.RightChild;
                                amount--;
                                return true;
                            }
                        }

                    }
                    else
                    {

                        if (findnode.Node.LeftChild != null && findnode.Node.RightChild == null)
                        {
                            if (findnode.Node.Parent == null)
                            {
                                Root = Root.LeftChild;
                                amount--;
                                return true;
                            }
                            else
                            {
                                if (findnode.Node.NodeKey < findnode.Node.Parent.NodeKey)
                                {
                                    findnode.Node.LeftChild.Parent = findnode.Node.Parent;
                                    findnode.Node.Parent.LeftChild = findnode.Node.LeftChild;
                                    amount--;
                                    return true;
                                }
                                else
                                {
                                    findnode.Node.LeftChild.Parent = findnode.Node.Parent;
                                    findnode.Node.Parent.RightChild = findnode.Node.LeftChild;
                                    amount--;
                                    return true;
                                }

                            }


                        }
                        else // when both children are not null 
                        {
                            BSTNode<T> replace = leftTravel(findnode.Node.RightChild);
                            if (findnode.Node.Parent == null)
                            {
                                Root = replace;
                                amount--;
                                return true;
                            }
                            else
                            {
                                if (findnode.Node.NodeKey < findnode.Node.Parent.NodeKey)
                                {
                                    replace.Parent = findnode.Node.Parent;
                                    findnode.Node.Parent.LeftChild = replace;
                                    amount--;
                                    return true;
                                }
                                else
                                {
                                    replace.Parent = findnode.Node.Parent;
                                    findnode.Node.Parent.RightChild = replace;
                                    amount--;
                                    return true;
                                }
                            }

                        }
                    }
                }

            }

        }

        public BSTNode<T> leftTravel(BSTNode<T> node) // walking on leftchilds
        {
            if (node.LeftChild != null)
            {
                BSTNode<T> rez = leftTravel(node.LeftChild);
                return rez;
            }
            else
            {
                if (node.RightChild == null) return node;
                else return node.RightChild;
            }
        }



        public int Count() // amount of all nodes in tree 
        {
            return amount;
        }

        public List<BSTNode<T>> WideAllNodes()  // travelling Method 
        { 
            List<BSTNode<T>> list = new List<BSTNode<T>>();
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            if (Root == null) return null;
            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var x = queue.Dequeue();
                list.Add(x);
                if (x.LeftChild != null) queue.Enqueue(x.LeftChild);
                if (x.RightChild != null) queue.Enqueue(x.RightChild);
            }
            return list;
        }

        public List<BSTNode<T>> DeepAllNodes(int param)  // travelling Method in deep 
        {
            if (Root == null) return null;
            if (param < 0 && param > 2) throw new ArgumentException();
            List<BSTNode<T>> list = new List<BSTNode<T>>();
            if (param == 0)
            {
                InOrder(list, Root);
                return list;
            }
            else
            {
                if (param == 1)
                {
                    PostOrder(list, Root);
                    return list;
                    
                }
                else
                {
                    PreOrder(list, Root);
                    return list;
                }
            }
        }

        public List<BSTNode<T>> PreOrder(List<BSTNode<T>> list,BSTNode<T> node) // travelling Method PreOrder
        {
            list.Add(node);
            if (node.LeftChild != null) PreOrder(list, node.LeftChild);
            if (node.RightChild != null) PreOrder(list, node.RightChild);
            return list;
        }

        public List<BSTNode<T>> PostOrder(List<BSTNode<T>> list, BSTNode<T> node) // travelling Method PostOrder
        {
            if (node.LeftChild != null) PostOrder(list, node.LeftChild);
            if (node.RightChild != null) PostOrder(list, node.RightChild);
            list.Add(node);
            return list;
        }

        public List<BSTNode<T>> InOrder(List<BSTNode<T>> list, BSTNode<T> node) // travelling Method InOrder
        {
            if (node.LeftChild != null) InOrder(list, node.LeftChild);
            list.Add(node);
            if (node.RightChild != null)InOrder(list, node.RightChild);
            return list;
        }

    }
}  
