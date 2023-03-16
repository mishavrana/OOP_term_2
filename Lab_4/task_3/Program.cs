using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;

namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        var publisher = new Publisher();

        var daySub = new DaySubscriber
        (
            2000,
            1000,
            10
        );

        var dataTime = new DateTimeSubscriber
        (
            1000,
            100,
            15
        );
        
        publisher.Subscribe(daySub.Run);
        publisher.Subscribe(dataTime.Run);
        
        publisher.Start();
    }
}

