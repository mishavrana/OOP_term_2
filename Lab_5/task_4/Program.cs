namespace Task_4;

using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int[,] _matrixA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
    static int[,] _matrixB = new int[3, 2] { { 7, 8 }, { 9, 10 }, { 11, 12 } };
    static int[,] _resultMatrix = new int[2, 2];

    static SemaphoreSlim _semaphore = new SemaphoreSlim(1);
    static object _lockObj = new object();
    static int _activeThreads = 0;

    static void Main(string[] args) 
    {
        // Creating threads for matrix multiplication
        Thread thread1 = new Thread(() => Multiply(0, 0, 0, 0, 0, 0));
        Thread thread2 = new Thread(() => Multiply(0, 0, 0, 1, 0, 1));
        Thread thread3 = new Thread(() => Multiply(1, 0, 0, 0, 1, 0));
        Thread thread4 = new Thread(() => Multiply(1, 0, 0, 1, 1, 1));
        
        // Start threads
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        // Wait for threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
        
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                Console.Write(_resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Multiply(int jMatrixA, int iMatrixA, int jMatrixB, int iMatrixB, int jResult, int iResult)
    {

        Monitor.Enter(_lockObj);
        var copyMatrixA = _matrixA;
        var copyMatrixB = _matrixB;
        Monitor.Exit(_lockObj);

        int jA = jMatrixA;
        int iA = iMatrixA;

        int jB = jMatrixB;
        int iB = iMatrixB;

        var result = 0;
        _semaphore.Release();
        for (var ia = iA; ia < 3; ia++)
        {
            for (var jb = ia - 1; jb < ia; jb++)
            {
                result += copyMatrixA[jA, ia] * copyMatrixB[jb + 1, iB];
            }

        }
        _resultMatrix[jResult, iResult] = result;
    }
}
