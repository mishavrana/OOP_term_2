namespace Task_4_1;

class Program
{
    
    static int[,] _matrixA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
    static int[,] _matrixB = new int[3, 2] { { 7, 8 }, { 9, 10 }, { 11, 12 } };
    static int[,] _resultMatrix = new int[2, 2];

    static SemaphoreSlim _semaphore = new SemaphoreSlim(4);
    static object _lockObj = new object();
    static int _activeThreads = 0;
    
    static void Main(string[] args)
    {
        // Creating threads
        Thread thread1 = new Thread(Calculate);
        Thread thread2 = new Thread(Calculate);
        Thread thread3 = new Thread(Calculate);
        Thread thread4 = new Thread(Calculate);
        
        // Starting threads
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        
        Calculate();
    }

    static void Calculate()
    {
        Console.WriteLine("Starting calculating...");
        _semaphore.Wait();
        Monitor.Enter(_lockObj);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                _resultMatrix[i, j] = 0;

                for (int k = 0; k < 3; k++)
                {
                    
                    _resultMatrix[i, j] += _matrixA[i, k] * _matrixB[k, j];
                }
            }
        }
        Console.WriteLine("Calculated");
        Output();
        Monitor.Exit(_lockObj);
        _semaphore.Release();
    }

    static void Output()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(_resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}