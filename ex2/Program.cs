using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int size = 100_000_000; // גודל המערך לניסוי
        int[] arr = new int[size];

        Console.WriteLine("Array created.");

        MeasureSequential(arr);
        MeasureStrided(arr, 64);
        MeasureStrided(arr, 256);
        MeasureStrided(arr, 1024);
    }

    static void MeasureSequential(int[] arr)
    {
        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;

        for (int i = 0; i < arr.Length; i++)
            sum += arr[i];

        sw.Stop();
        Console.WriteLine($"Sequential: {sw.ElapsedMilliseconds} ms  (sum={sum})");
    }

    static void MeasureStrided(int[] arr, int stride)
    {
        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;

        for (int i = 0; i < arr.Length; i += stride)
            sum += arr[i];

        sw.Stop();
        Console.WriteLine($"Stride {stride}: {sw.ElapsedMilliseconds} ms  (sum={sum})");
    }
}
