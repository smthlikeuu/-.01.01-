 using System;
using System.Diagnostics;

namespace PracticalWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа №1");
            Console.WriteLine("Генерация массива, сортировка двумя способами, замер времени");
            Console.WriteLine();

            
            int[] original = GenerateUniqueArray(1000);

            Console.WriteLine("Исходный массив:");
            PrintArray(original);
            Console.WriteLine();

            
            int[] arrayForBubble = CopyArray(original);
            int[] arrayForSelection = CopyArray(original);

           
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            BubbleSort(arrayForBubble);
            sw1.Stop();

            Console.WriteLine("Массив после сортировки пузырьком:");
            PrintArray(arrayForBubble);
            Console.WriteLine();

            
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            SelectionSort(arrayForSelection);
            sw2.Stop();

            Console.WriteLine("Массив после сортировки выбором:");
            PrintArray(arrayForSelection);
            Console.WriteLine();

           
            double bubbleTime = sw1.Elapsed.TotalMilliseconds;
            double selectionTime = sw2.Elapsed.TotalMilliseconds;

            Console.WriteLine("Время сортировки пузырьком: " + bubbleTime + " мс");
            Console.WriteLine("Время сортировки выбором: " + selectionTime + " мс");

            
            double diff = Math.Abs(bubbleTime - selectionTime);
            Console.WriteLine("Разница во времени: " + diff + " мс");

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        
        static int[] GenerateUniqueArray(int size)
        {
            int[] result = new int[size];
            Random rnd = new Random();
            int count = 0;

            while (count < size)
            {
                int number = rnd.Next(1, 100000); 

                
                bool alreadyExists = false;
                for (int i = 0; i < count; i++)
                {
                    if (result[i] == number)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if (!alreadyExists)
                {
                    result[count] = number;
                    count++;
                }
            }

            return result;
        }

        
        static int[] CopyArray(int[] source)
        {
            int[] copy = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = source[i];
            }
            return copy;
        }

        
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}