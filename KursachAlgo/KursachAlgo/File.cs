using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace KursachAlgo
{
    public class File : IComparable
    {
        public string Name { get; set; }

        public File(string name)
        {
            Name = name;
        }

        public int CompareTo(File otherFile)
        {
            return Name.CompareTo(otherFile.Name);
        }

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
