using System;
using System.Collections.Generic;

namespace KursachAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> root = new Node<string>("root");
            SimpleFileSystem<string> sfs = new SimpleFileSystem<string>(root);

            Node<string> system = new Node<string>("system");
            sfs.AddFile(system, root);

            Node<string> drivers = new Node<string>("drivers");
            sfs.AddFile(drivers, system);

            Node<string> configs = new Node<string>("configs");
            sfs.AddFile(configs, system);

            Node<string> users = new Node<string>("users");
            sfs.AddFile(users, root);

            Node<string> john = new Node<string>("john");
            sfs.AddFile(john, users);

            Node<string> alex = new Node<string>("alex");
            sfs.AddFile(alex, users);

            Console.WriteLine("Path to 'drivers':");
            sfs.ShowPathToFile(drivers, "/");
            Console.WriteLine("\n\nPath to 'configs':");
            sfs.ShowPathToFile(configs, "/");

            Console.WriteLine("\n\nPath to 'john':");
            sfs.ShowPathToFile(john, "/");
            Console.WriteLine("\n\nPath to 'alex':");
            sfs.ShowPathToFile(alex, "/");



            Node<string> flashCard = new Node<string>("flash-card");
            SimpleFileSystem<string> flashCardSfs = new SimpleFileSystem<string>(flashCard);

            Node<string> music = new Node<string>("music");
            flashCardSfs.AddFile(music, flashCard);

            Node<string> films = new Node<string>("films");
            flashCardSfs.AddFile(films, flashCard);

            Node<string> comedies = new Node<string>("comedies");
            flashCardSfs.AddFile(comedies, films);

            Console.WriteLine("\n\nMounting flashcard file system to the main file system...");
            sfs.Mount(flashCardSfs);

            Console.WriteLine("\nPath to 'music':");
            sfs.ShowPathToFile(music, "/");
            Console.WriteLine("\n\nPath to 'comedies':");
            sfs.ShowPathToFile(comedies, "/");

            Console.WriteLine("\n\nUnmounting flashcard file system from the main file system...");

            sfs.Unmount(flashCardSfs);

            Console.WriteLine("\nPath to 'music':");
            sfs.ShowPathToFile(music, "/");
            Console.WriteLine("\n\nPath to 'comedies':");
            sfs.ShowPathToFile(comedies, "/");

            Console.WriteLine();
        }
    }
}
