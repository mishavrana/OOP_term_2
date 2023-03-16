using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;

namespace Task_1;

public class EventBus
{
    private readonly int _throttle;
    
    // List to save the event handlers
    private ObservableCollection<EventHandler> _handlers = new ObservableCollection<EventHandler>();

    // Register an ivent
    public void Register(EventHandler handler)
    {
        this._handlers.Add(handler);
    }
    
    // Unregister an ivent
    public void UnRegister(EventHandler handler)
    {
        _handlers.Remove(handler);
    }
    
    // Sends an event to the handlers
    public void GetHandlers(object sender, EventArgs eventArgs)
    {
        while (true)
        {
            if (_handlers != null)
            {
                for(var i = 0; i < _handlers.Count; i++ )
                {
                    _handlers[i].Invoke(sender, eventArgs);
                    
                    // Implementing throttling 
                    Thread.Sleep(_throttle);  
                }  
            }
        }
    }
    
    // Init 
    public EventBus(int throttle)
    {
        _throttle = throttle;
    }
}