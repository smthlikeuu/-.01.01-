using System;

namespace PracticalWork2
{
    class Node
    {
        public char Data;
        public Node Next;
        public Node Prev;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа №2: двусвязный список");
            Console.WriteLine("Вариант 7 (добавить символы в обратном порядке в конец)");
            Console.WriteLine();

            Console.Write("Введите строку символов: ");
            string input = Console.ReadLine();

            Node head = null;
            Node tail = null;

            for (int i = 0; i < input.Length; i++)
            {
                Node newNode = new Node();
                newNode.Data = input[i];
                newNode.Next = null;
                newNode.Prev = tail;

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Исходный список:");
            PrintList(head);

            AddReversedToEnd(ref head, ref tail);

            Console.WriteLine();
            Console.WriteLine("Результат после преобразования:");
            PrintList(head);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void PrintList(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        static void AddReversedToEnd(ref Node head, ref Node tail)
        {
            Node current = tail.Prev;
            while (current != null)
            {
                Node newNode = new Node();
                newNode.Data = current.Data;
                newNode.Next = null;
                newNode.Prev = tail;

                tail.Next = newNode;
                tail = newNode;

                current = current.Prev;
            }
        }
    }
}