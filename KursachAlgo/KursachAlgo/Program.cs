using System;
using System.Collections.Generic;

namespace KursachAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            //lv 0
            Node<string> m = new Node<string>("m");

            //lv 1
            Node<string> a = new Node<string>("a", m);
            m.Children.Add(a);

            //lv 2
            Node<string> b = new Node<string>("b", a);
            Node<string> c = new Node<string>("c", a);
            a.Children.Add(b);
            a.Children.Add(c);

            //lv 3
            Node<string> d = new Node<string>("d", b);
            Node<string> f = new Node<string>("f", b);
            Node<string> h = new Node<string>("h", b);
            Node<string> g = new Node<string>("g", c);
            b.Children.Add(d);
            b.Children.Add(f);
            b.Children.Add(h);
            c.Children.Add(g);

            Tree<string> tree = new Tree<string>(a);

            Stack<Node<string>> st = new Stack<Node<string>>();

            List<Node<string>> list = new List<Node<string>>();


            List<Node<string>> bfsList = new List<Node<string>>();

            bfsList = tree.orderBFS(m);

            tree.PrintPath(bfsList);

            Console.WriteLine();

            tree.PrintPath(tree.FindPath(f, bfsList));
        }
    }
}
