namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        var publisher = new Publisher();

        var dateSub = new DateTimeSubscriber();
        var daySub = new DaySubscriber();
        
        
        
        publisher.Subscribe(dateSub.Display);
        publisher.Subscribe(daySub.Display);
        
        publisher.Start();
    }
}

