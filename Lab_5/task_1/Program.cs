using task_1;

class Program
{
    static private Queue<int> _queue = new Queue<int>();
    static private object _lockObject = new object();
    
    static private Producer _producer = new Producer(_queue, _lockObject);
    static private Consumer _consumer = new Consumer(_queue, _lockObject);

    static void Main(string[] args)
    {
        Thread producerThread = new Thread(new ThreadStart(_producer.Produce));
        Thread consumerThread = new Thread(new ThreadStart(_consumer.Consume));
        
        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();
        
        Console.WriteLine("Done");
    }
}
