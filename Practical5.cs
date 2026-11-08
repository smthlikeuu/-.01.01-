static void Main(string[] args)
{
    Console.Write("Введите длину массива: ");
    int length = int.Parse(Console.ReadLine());

    int[] array = new int[length];

    FillArray(array);
    PrintArray(array);

    Console.WriteLine();
    Console.WriteLine("Среднее арифметическое: {0}", CalculateAverage(array));

    Console.ReadKey();
}

static void FillArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = i * 2;
    }
}

static void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

static double CalculateAverage(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }

    return (double)sum / array.Length;
}