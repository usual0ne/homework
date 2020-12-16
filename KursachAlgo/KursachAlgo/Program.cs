using System;
using System.Collections.Generic;

namespace KursachAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> root = new Node<string>("root");

            Node<string> me = new Node<string>("me");

            Node<string> mom = new Node<string>("mom");

            Node<string> photos = new Node<string>("photos");

            SimpleFileSystem<string> sfs = new SimpleFileSystem<string>(root);

            
            sfs.AddFile(me, root);

            sfs.AddFile(mom, root);

            sfs.AddFile(photos, me);

            sfs.ShowPathToFile(photos, "/");



            /*//lv 0
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


            List<Node<string>> bfsList = new List<Node<string>>();

            *//*bfsList = tree.orderBFS(m);

            tree.PrintPath(bfsList);

            Console.WriteLine();

            tree.PrintPath(tree.FindPath(g, bfsList));*/

            /*Node<string> k = new Node<string>("k");
            Node<string> l = new Node<string>("l", k);
            Node<string> z = new Node<string>("z", k);
            k.Children.Add(l);
            k.Children.Add(z);

            Tree<string> subtree = new Tree<string>(k);

            tree.InsertNode(k, b);

            bfsList = tree.orderBFS(m);
            //tree.PrintPath(tree.FindPath(l, bfsList));
            tree.PrintPath(bfsList);

            Console.WriteLine("\nDisconnect k subtree:");

            tree.DeleteNode(k, b);
            bfsList = tree.orderBFS(m);
            tree.PrintPath(bfsList);*//*

            Node<string> o = new Node<string>("o");

            tree.InsertNode(o, a);
            bfsList = tree.orderBFS(m);
            tree.PrintPath(bfsList);

            Console.WriteLine();

            tree.DeleteNode(o, a);
            bfsList = tree.orderBFS(m);
            tree.PrintPath(bfsList);*/
        }
    }
}
