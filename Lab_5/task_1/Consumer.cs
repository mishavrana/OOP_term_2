namespace task_1;

public class Consumer
{
    private Queue<int> _queue;
    private object _lockObject;

    public void Consume()
    {
        while (true)
        {
            int number;
            
            Monitor.Enter(_lockObject);
            
            if (_queue.Count == 0)
            {
                break;
            }
            
            number = _queue.Dequeue();
            Console.WriteLine($"Consumed: {number}");
            Monitor.Exit(_lockObject);

            Thread.Sleep(1000);
        }
    }
    
    public Consumer(Queue<int> queue, object lockObject)
    {
        _queue = queue;
        _lockObject = lockObject;
    }
}