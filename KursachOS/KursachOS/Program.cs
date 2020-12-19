using System;
using System.IO;

namespace KursachOS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords;            
            using (StreamReader streamReader = new StreamReader(args[0]))
            {
                string input = streamReader.ReadLine();
                inputWords = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            }
            try
            {
                Node<string> root = new Node<string>(inputWords[0]);
                Tree<string> tree = new Tree<string>(root);

                for(int i = 1; i < inputWords.Length; i++)
                {
                    Node<string> wordNode = new Node<string>(inputWords[i]);
                    tree.AddNode(wordNode, root);
                }

                Console.WriteLine(root.Value);
                foreach (var child in root.Children)
                {
                    Console.WriteLine(child.Value);
                }

                Console.WriteLine("_________________________");
                Console.WriteLine("Delete second word");
                Console.WriteLine("_________________________");

                //second word aka first child of the root
                tree.DeleteNode(root.Children[0], root);

                Console.WriteLine(root.Value);
                foreach (var child in root.Children)
                {
                    Console.WriteLine(child.Value);
                }

                Console.WriteLine("_________________________");
                Console.WriteLine("Add one more word");
                Console.WriteLine("_________________________");

                Node<string> flashcard = new Node<string>("flashcard");
                tree.AddNode(flashcard, root);

                Console.WriteLine(root.Value);
                foreach (var child in root.Children)
                {
                    Console.WriteLine(child.Value);
                }

                File.WriteAllText(args[0], "");

                using (StreamWriter streamWriter = new StreamWriter(args[0], true, System.Text.Encoding.Default))
                {
                    streamWriter.WriteLine(root.Value);
                    foreach (var child in root.Children)
                    {
                        streamWriter.WriteLine(child.Value);
                    }
                }


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
