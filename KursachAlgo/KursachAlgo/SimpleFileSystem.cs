using System;
using System.Collections.Generic;
using System.Text;

namespace KursachAlgo
{
    public class SimpleFileSystem<T> : Tree<T> where T : IComparable
    {
        //private KursachAlgo.File root;

        public SimpleFileSystem(Node<T> root) : base(root)
        {
            this.Root = root;
        }

        public void Mount(SimpleFileSystem<T> outerFileSystem)
        {
            this.AddFile(outerFileSystem.Root, this.Root);
        }

        public void UnMount(SimpleFileSystem<T> innerFileSystem)
        {
            this.DeleteNode(innerFileSystem.Root, this.Root);
        }

        public void ShowPathToFile(Node<T> file, string delimiter)
        {
            PrintPath(FindPath(file, this.orderBFS(this.Root)), delimiter);
        }

        public void AddFile(Node<T> newFile, Node<T> previousFile)
        {
            this.AddNode(newFile, previousFile);
        }

        public void DeleteFile(Node<T> fileToBeDeleted, Node<T> previousFile)
        {
            this.DeleteNode(fileToBeDeleted, previousFile);
        }        
    }
}
