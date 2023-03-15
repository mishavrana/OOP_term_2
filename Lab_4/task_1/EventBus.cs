using System;
using System.ComponentModel;
using System.Threading;

namespace Task_1;

public class EventBus
{
    private readonly int _throttle;
    
    // Dictionary to save the event name and it's handler
    private Dictionary<string, Action> _eventMethods = new Dictionary<string, Action>();

    // Init 
    public EventBus(int throttle)
    {
        _throttle = throttle;
    }
    
    // Register event
    // Event handlers are added by the name of the event
    public void Subscribe(string eventType, Action eventHandler)
    {
        if (!_eventMethods.ContainsKey(eventType))
        {
            _eventMethods.Add(eventType, eventHandler);
        }
    }
    
    // Unregister event
    // Event handlers are deleted by the name of the event
    public void UnSubscribe(string eventType)
    {
        if (_eventMethods.ContainsKey(eventType))
        {
            _eventMethods.Remove(eventType);
        }
    }
    
    // Dispatch event
    // 'userEvent' gets the handler according to a key with a throttle
    public void Dispatch(string eventType, Action userEvent)
    {
        if (_eventMethods.ContainsKey(eventType))
        {
            var handler = _eventMethods[eventType];
            userEvent += handler;
            userEvent?.Invoke();
            
            // Throttle the event dispatch.
            Thread.Sleep(_throttle);
        }
    }
}