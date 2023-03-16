using System;
using System.Threading;
using Microsoft.VisualBasic;

namespace Task_2;

public class Publisher: IPublisher
{
    
    // Subscribe to the event
    private event DateTimeDelegate? DateTimeEvent;
    
    
    public void Subscribe(DateTimeDelegate dateTimeHandler)
    {
        DateTimeEvent += dateTimeHandler;
    }
    
    // Start publishing
    public void Start()
    {

        if (DateTimeEvent != null)
        {
            DateTimeEvent(DateTime.Now);
        }
        Thread.Sleep(1000);
    }

}