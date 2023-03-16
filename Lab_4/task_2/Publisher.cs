using Microsoft.VisualBasic;

namespace Task_2;

public class Publisher: IPublisher
{
    
    // Subscribe to the event
    private event DateTimeDelegate? _dateTimeEvent;
    
    
    public void Subscribe(DateTimeDelegate dateTimeHandler)
    {
        _dateTimeEvent += dateTimeHandler;
    }
    
    // Start publishing
    public void Start()
    {
        while (true)
        {
            if (_dateTimeEvent != null)
                _dateTimeEvent(DateTime.Now);

            Thread.Sleep(1000);
        }
    }

}