namespace Task_3;

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            arr[i] = int.Parse(args[i]);
        }

        QuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);

            Thread t1 = new Thread(() => QuickSort(arr, left, pivotIndex - 1));
            Thread t2 = new Thread(() => QuickSort(arr, pivotIndex + 1, right));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j <= right - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, right);
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
