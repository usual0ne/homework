using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KursachAlgo
{
    public class Tree<T> where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public Tree(Node<T> root)
        {
            this.Root = root;
        }


        //Prints path from the root to chosen node
        public void PrintPath(List<Node<T>> path)
        {
            foreach (var node in path)
            {
                Console.Write(node.Value + " ");
            }
        }


        //Finds path from the root to chosen node
        public List<Node<T>> FindPath(Node<T> searchNode, List<Node<T>> orderBFSList)
        {            
            List<Node<T>> path = new List<Node<T>>();

            if (orderBFSList.Contains(searchNode))
            {
                var current = searchNode;
                path.Add(current);

                //search for connected vertices beginning from the end of orderBFSList
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

        public List<Node<T>> orderBFS(Node<T> root)
        {
            var queue = new Queue<Node<T>>();
            var result = new List<Node<T>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node<T> child = queue.Dequeue();
                result.Add(child);
                foreach(var c in child.Children)
                {
                    queue.Enqueue(c);
                }
            }

            return result;
        }
    }
}

