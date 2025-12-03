using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Start memory allocation test...");

        long low = 1;
        long high = 2_000_000_000; // להתחיל מגבול גדול
        long maxSize = 0;

        while (low <= high)
        {
            long mid = (low + high) / 2;
            try
            {
                int[] arr = new int[mid];
                maxSize = mid;
                low = mid + 1;
            }
            catch (OutOfMemoryException)
            {
                high = mid - 1;
            }
        }

        Console.WriteLine($"Max array size = {maxSize:N0} ints");
        Console.WriteLine($"Approx memory = {maxSize * 4 / (1024.0 * 1024.0):F2} MB");
    }
}
