using MiNET.Plugins;
using System;
using System.Collections.Generic;

namespace Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
;           Console.WriteLine();
        }

        static void Task1()
        {
            string[] str = Console.ReadLine().Split(" ");
            int strLastIndex = str.Length - 1;
            Action<string> print = message => Console.WriteLine(message);
            string[] strReverse = new string[str.Length];

            for(int i = 0; i < str.Length; i++)
            {
                strReverse[i] = str[strLastIndex - i];
            }

            foreach (var s in strReverse)
            {
                print(s);
            }
        }
    }
}
