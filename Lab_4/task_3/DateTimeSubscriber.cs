using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2;

public class DateTimeSubscriber
{
    private int _throttle;
    public int? TimesToRepeat { get; }
    public int MaximalThrottle { get; }

    public int Throttle
    {
        get { return _throttle; }
        set
        {
            _throttle = value;
            if (_throttle > MaximalThrottle)
                _throttle = MaximalThrottle;
        }
    }
    
    private event Action? Display;
    public void Run(DateTime dateTime)
    {
        Thread thread = new Thread(new ThreadStart(Display));
        thread.Start();
    }

    private void IncreaseThrottle()
    {
        Random randomize = new Random();
        Throttle += randomize.Next(10, 50);
    }
    
    // Init
    public DateTimeSubscriber(int maximalThrottle, int throttle, int? timesToRepeat = null)
    {
        TimesToRepeat = timesToRepeat;
        MaximalThrottle = maximalThrottle;
        Throttle = throttle;
        
        // Closure that controls times to repeat, throttle and the sycle
        Display += delegate()
        {
            if (TimesToRepeat == null)
            {
                while (true)
                {
                    Console.WriteLine("Date time: " + DateTime.Now);
                    Thread.Sleep(Throttle);
                    IncreaseThrottle();
                }
            }
            else
            {
                for (int i = 0; i < TimesToRepeat; i++)
                {
                    Console.WriteLine("Date time: " + DateTime.Now);
                    Thread.Sleep(_throttle);
                    IncreaseThrottle();
                }
            }
            
        };
    }
}