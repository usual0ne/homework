using System;
using System.Collections;
using System.Collections.Generic;

namespace ListHW
{
    class Program
    {
        public class Minion
        {
            public string Name{ get; set; }
            public int Age { get; set; }
            public int TownId { get; set; }

            public Minion(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        public class Node<T>
        {
            public T Element { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T element) { this.Element = element; }
        }

        public class DoublyLinkedList<T> : IEnumerable<T>
        {
            private Node<T> head;
            private Node<T> tail;
            private int size;

            public DoublyLinkedList() 
            {
                this.head = null;
                this.tail = null;
                this.size = 0;
            }

            public void AddLast(T element)
            {
                Node<T> newNode = new Node<T>(element);
                if(this.tail == null)
                {
                    this.tail = newNode;
                    this.head = newNode;
                }
                else
                {
                    this.tail.Next = newNode;
                    newNode.Previous = this.tail;
                    this.tail = newNode;
                }                
                this.size++;
            }

            public void AddFirst(T element)
            {
                Node<T> newNode = new Node<T>(element);
                if(this.head == null)
                {
                    this.head = newNode;
                    this.tail = newNode;
                }

                else
                {
                    this.head.Previous = newNode;
                    newNode.Next = this.head;
                    this.head = newNode;
                }
                this.size++;
            }

            public void AddByIndex(T element, int index)
            {
                Node<T> newNode = new Node<T>(element);
                if (this.size == 0)
                {
                    this.head = newNode;
                    this.tail = newNode;
                    this.AddFirst(element);
                    this.size++;
                }

                else if (index == this.size + 1)
                {
                    this.AddLast(element);
                    this.size++;
                }

                else if(index <= this.size & index > 0)
                {
                    Node<T> current = this.head;
                    int counter = 1;
                    while(counter < index)
                    {
                        current = current.Next;
                        counter++;
                    }

                    current.Previous.Next = newNode;
                    newNode.Previous = current.Previous;
                    current.Previous = newNode;
                    newNode.Next = current;

                    size++;
                }
            }

            public void Edit(int index, T element)
            {
                Node<T> current = this.head;
                int counter = 1;
                while (counter < index)
                {
                    current = current.Next;
                    counter++;
                }
                current.Element = element;
            }

            public Node<T> this[int index]
            {
                get
                {
                    if (index < 0 || index >= this.size)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    Node<T> current = this.head;
                    int counter = 0;
                    while (counter < index)
                    {
                        current = current.Next;
                        counter++;
                    }
                    return current;
                }

                set
                {
                    Node<T> current = this.head;
                    int counter = 0;
                    while (counter < index)
                    {
                        current = current.Next;
                        counter++;
                    }

                    current = value;
                }
            }

            public void Delete(int index)
            {
                if (index == 1)
                {
                    this.head.Next.Previous = null;
                    this.head = this.head.Next;
                }

                else if (index == size)
                {
                    this.tail.Previous.Next = null;
                    this.tail = this.tail.Previous;
                }

                else
                {
                    Node<T> current = this.head;
                    int counter = 1;
                    while (counter < index)
                    {
                        current = current.Next;
                        counter++;
                    }
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;

                    current.Previous = null;
                    current.Next = null;
                }
                size--;
            }

            public IEnumerator<T> GetEnumerator()
            {
                Node<T> current = this.head;
                while (current != null)
                {
                    yield return current.Element;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

        }

        static void Main(string[] args)
        {
            Minion m1 = new Minion("John", 24);
            Minion m2 = new Minion("Vasya", 13);
            Minion m3 = new Minion("Kolya", 52);
            Minion m4 = new Minion("Petya", 18);
            DoublyLinkedList<Minion> myList = new DoublyLinkedList<Minion>();


            Console.WriteLine("Добавляем:\n");
            myList.AddLast(m1);
            myList.AddLast(m2);
            myList.AddLast(m3);
            myList.AddByIndex(m4, 3);


            //работа индексатора
            Console.WriteLine(myList[1].Element.Age);


            //работа итератора
            foreach (Minion m in myList)
            {
                Console.WriteLine(m.Age + " " + m.Name);
            }



            Console.WriteLine("\n\n");
            Console.WriteLine("Удаляем первый:\n");
            myList.Delete(1);
            foreach (Minion m in myList)
            {
                Console.WriteLine(m.Age + " " + m.Name);
            }


            Console.WriteLine("\n\n");
            Console.WriteLine("Редактируем второй:\n");
            Minion m5 = new Minion("Phedya", 30);
            myList.Edit(2, m5);

            foreach (Minion m in myList)
            {
                Console.WriteLine(m.Age + " " + m.Name);
            }
        }
    }
}
