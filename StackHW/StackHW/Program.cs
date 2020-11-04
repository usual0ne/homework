using System;
using System.Collections;
using System.Collections.Generic;

namespace StackHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(8);
            stack.Push(7);
            stack.Push(6);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            Console.WriteLine("operation 'Push' result:\n");
            Console.WriteLine("Count: " + stack.Count + "\tCapacity: " + stack.Capacity);
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }

            
            stack.Push(1);
            Console.WriteLine("\npush one new element to the stack\n");
            Console.WriteLine("Count: " + stack.Count + "\tCapacity: " + stack.Capacity);
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }


            stack.Pop();
            Console.WriteLine("\noperation 'Pop' result:\n");
            Console.WriteLine("Count: " + stack.Count + "\tCapacity: " + stack.Capacity);
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }

           
            Console.WriteLine("\noperation 'Peek' result:\n");
            Console.WriteLine(stack.Peek());
        }

        public class Stack<T> : IEnumerable<T>
        {
            private readonly int initialCapacity = 2;
            private T[] elements;

            public int Count { get; private set; }

            public int Capacity
            {
                get
                {
                    return this.elements.Length;
                }
            }

            public Stack() 
            {
                this.Count = 0;
                this.elements = new T[this.initialCapacity];
            }

            public void Push(T element)
            {
                this.elements[Count] = element;
                this.Count++;
                if(this.Count == this.Capacity)
                {
                    this.Expand();
                }
            }

            public void Pop()
            {
                T[] copy = new T[this.Capacity];
                for(int i = 0; i < Capacity - 1; i++)
                {
                    copy[i] = elements[i];
                }
                this.elements = copy;
                this.Count--;
            }

            public T Peek()
            {
                return this.elements[Count - 1];
            }

            private void Expand()
            {
                T[] copy = new T[this.Capacity * 2];
                for(int i = 0; i < elements.Length; i++)
                {
                    copy[i] = elements[i];
                }
                this.elements = copy;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for(int i = this.Count - 1; i >= 0; i--)
                {
                    yield return this.elements[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
