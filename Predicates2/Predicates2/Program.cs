using System;
using System.Collections.Generic;

namespace Predicates2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task4();
        }

        static void Task1()
        {

            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] nums = new int[str.Length];

            for(int i = 0; i < str.Length; i++)
            {
                nums[i] = Convert.ToInt32(str[i]);
            }

            string input = Console.ReadLine();

            int Operation(int number, Func<int, int> operation)
            {
                return operation(number);
            }

            while (input != "end")
            {
                if (input == "print")
                {
                    foreach (int n in nums)
                    {
                        Console.Write(n + " ");
                    }
                    Console.Write("\n");
                }

               if (input == "add")
               {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = Operation(nums[i], n => n + 1);
                    }
               }

                if (input == "multiply")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = nums[i] = Operation(nums[i], n => n * 2);
                    }
                }

                if (input == "subtract")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = nums[i] = Operation(nums[i], n => n - 1);
                    }
                }

                input = Console.ReadLine();
            }
        }


        static void Task2()
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int divisor = int.Parse(Console.ReadLine());

            List<int> nums = new List<int>();

            for(int i = 0; i < str.Length; i++)
            {
                nums.Add(Convert.ToInt32(str[(str.Length - 1) - i]));
            }

            Func<int, bool> isDivisible = number => number % divisor == 0;

            for (int i = 0; i < nums.Count; i++)
            {
                if (isDivisible(nums[i]))
                {
                    nums.RemoveAt(i);
                }
            }

            foreach (var n in nums)
            {
                Console.Write(n + " ");
            }
        }

        static void Task3()
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int length = int.Parse(Console.ReadLine());

            Func<string, bool> validLength = s => s.Length <= length; 

            foreach(var s in str)
            {
                if (validLength(s))
                {
                    Console.Write(s + " ");
                }
            }
        }


        static void Task4()
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] allNums = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                allNums[i] = Convert.ToInt32(str[i]);
            }

            List<int> evenNums = new List<int>();
            List<int> oddNums = new List<int>();

            Func<int, bool> isEven= number => number % 2 == 0;

            for (int i = 0; i < allNums.Length; i++)
            {
                if(isEven(allNums[i]))
                {
                    evenNums.Add(allNums[i]);
                }
                else
                {
                    oddNums.Add(allNums[i]);
                }
            } 

            IntComparator ic = new IntComparator();

            Array.Sort(evenNums.ToArray(), ic);

            for(int i = 0; i < evenNums.Count; i++)
            {
                allNums[i] = evenNums[i];
            }

            for(int i = evenNums.Count; i < allNums.Length; i++)
            {
                allNums[i] = oddNums[i - evenNums.Count];
            }

            foreach (var n in allNums)
            {
                Console.Write(n + " ");
            }
        }

        public class IntComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }
    }
}
