using System.Reflection.Metadata;

namespace Task_1;

class Program
{
    // Events
    private static event Action? EventOne;
    private static event Action? EventTwo;


    static void Main(string[] args)
    {
        // Creating an instance of an 'EventBus'
        EventBus eventBus = new EventBus(10000);
        
        // Register event handlers for the events
        eventBus.Subscribe("eventOne", HandleEventOne);
        eventBus.Subscribe("eventTwo", HandleEventTwo);

        // Activate the 'eventOne' and 'eventTwo' for two times each
        for (int i = 0; i < 2; i++)
        {
            eventBus.Dispatch("eventOne", EventOne);
            //Thread.Sleep(200);
            eventBus.Dispatch("eventTwo", EventTwo);
            //Thread.Sleep(200);
        }
        
        // Unregister events
        eventBus.UnSubscribe("eventOne");
        eventBus.UnSubscribe("eventTwo");

        // Event handlers
        static void HandleEventOne()
        {
            Console.WriteLine("Handled event #1");
        }

        static void HandleEventTwo()
        {
            Console.WriteLine("Handled event #2");
        }
    }
}
