using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KursachAlgo
{
    public class Tree<T> where T : IComparable
    {
        protected Node<T> Root { get; set; }

        public Tree(Node<T> root)
        {
            this.Root = root;
        }


        //Prints path from the root to chosen node
        protected void PrintPath(List<Node<T>> path, string delimiter)
        {
            for(int i = path.Count - 1; i > 0; i--)
            {
                Console.Write(path[i].Value + delimiter);
            }
            Console.Write(path[0].Value);
        }

        //Finds path from the root to chosen node
       protected List<Node<T>> FindPath(Node<T> searchNode, List<Node<T>> orderBFSList)
       {
            List<Node<T>> path = new List<Node<T>>();

            if (orderBFSList.Contains(searchNode))
            {
                var current = searchNode;
                path.Add(current);

                //search for connected to searchNode vertices beginning from the end of orderBFSList
                int index = orderBFSList.IndexOf(searchNode);
                for (int i = index; i >= 0; i--)
                {
                    if (orderBFSList[i].Value.CompareTo(current.Parent.Value) == 0)
                    {
                        path.Add(orderBFSList[i]);
                        current = orderBFSList[i];
                    }
                }
            }

            return path;
        }

        protected List<Node<T>> orderBFS(Node<T> root)
        {
            var queue = new Queue<Node<T>>();
            var result = new List<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> child = queue.Dequeue();
                result.Add(child);
                foreach (var c in child.Children)
                {
                    queue.Enqueue(c);
                }
            }

            return result;
        }

        protected void AddNode(Node<T> insertionNode, Node<T> connectionNode)
        {
            connectionNode.Children.Add(insertionNode);
            insertionNode.Parent = connectionNode;
        }

        protected void DeleteNode(Node<T> deletionNode, Node<T> connectionNode)
        {
            deletionNode.Parent = null;
            connectionNode.Children.Remove(deletionNode);
        }      
    }
}

