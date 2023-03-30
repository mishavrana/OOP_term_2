namespace task_1;

public class Producer
{
    private Queue<int> _queue;
    private object _lockObject;
    
    private Random _random = new Random();
    
    //Producing numbers 
    public void Produce()
    {
        for (int i = 0; i < 10; i++)
        {
            int number = _random.Next(1, 100); 
            
            Monitor.Enter(_lockObject);
            _queue.Enqueue(number);
            Console.WriteLine($"Produced: {number}");
            Monitor.Pulse(_lockObject);
            Monitor.Exit(_lockObject);

            Thread.Sleep(500);
        }
    }

    public Producer(Queue<int> queue, object lockObject)
    {
        _queue = queue;
        _lockObject = lockObject;
    }
}