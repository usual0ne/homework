using MiNET.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
           Task4();
           Console.WriteLine();
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


        static void Task2()
        {
            string[] str = Console.ReadLine().Split(" ");
            Action<string> print = message => Console.WriteLine(message);
            foreach (var s in str)
            {
                print(s + " (нет в наличии)");
            }
        }


        static void Task3()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] nums = input.Split(new string[] { " " }, 
                StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            int minimum = Int32.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] < minimum)
                {
                    minimum = nums[i];
                }
            }

            Console.WriteLine(minimum);
        }


        static void Task4()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] range = input.Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            int leftBorder = range[0];
            int rightBorder = range[1];

            input = Console.ReadLine();
            if(input.Equals("odd"))
            {
                for(int i = leftBorder;  i <= rightBorder; i++)
                {
                    if(i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }

            else if (input.Equals("even"))
            {
                for (int i = leftBorder; i <= rightBorder; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
