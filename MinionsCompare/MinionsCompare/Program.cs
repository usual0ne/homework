using System;
using System.Collections;
using System.Collections.Generic;

namespace MinionsCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Minion m1 = new Minion("Andrew", 26);
            Minion m2 = new Minion("Martin", 13);

            IComparer<Minion> comparer = new MinionComparer();

            Console.WriteLine(comparer.Compare(m1, m2));

        }

        public class Minion
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Minion(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        public class MinionComparer : IComparer<Minion>
        {
            public int Compare(Minion firstMinion, Minion secondMinion)
            {
                int result = firstMinion.Age.CompareTo(secondMinion.Age);
                if (result == 0)
                {
                    result = firstMinion.Name.CompareTo(secondMinion.Name);
                }
                return result;
            }
        }
    }
}
