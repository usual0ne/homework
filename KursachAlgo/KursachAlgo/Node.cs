using System;
using System.Collections.Generic;
using System.Text;

namespace KursachAlgo
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }

        public Node(T value, Node<T> parent = null)
        {
            this.Children = new List<Node<T>>();
            this.Value = value;
            this.Parent = parent;
        }
    }
}
