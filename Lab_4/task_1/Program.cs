using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        Handler handler = new Handler();
        EventBus eventBus = new EventBus(200);
        
        // Subscribe to event
        handler.DateTimeEvent += eventBus.GetHandlers;
        
        // Register handlers
        eventBus.Register(DisplayTodayDate);
        eventBus.Register(DisplayTomorrowDay);
        
        // Running in different thread allows to dynamically register and unregister handlers
        var loopThread = new Thread(handler.Run);
        loopThread.Start();
        
        Thread.Sleep(1000);
        eventBus.UnRegister(DisplayTomorrowDay);
        eventBus.UnRegister(DisplayTodayDate);
        
        // Event handlers
        static void DisplayTodayDate(object sender, EventArgs eventArgs)
        {
            Console.WriteLine(DateTime.Now);
        }

        static void DisplayTomorrowDay(object sender, EventArgs eventArgs)
        {
            Console.WriteLine(DateTime.Now.AddDays(1));
        }
    }
}
