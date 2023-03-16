using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2;

public class DaySubscriber
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
        Throttle += randomize.Next(100, 200);
    }
    
    // Init
    public DaySubscriber(int maximalThrottle, int throttle, int? timesToRepeat = null)
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
                    Console.WriteLine("Day: " + DateTime.Now.DayOfWeek);
                    Thread.Sleep(Throttle);
                    IncreaseThrottle();
                }
            }
            else
            {
                for (int i = 0; i < TimesToRepeat; i++)
                {
                    Console.WriteLine("Day: " + DateTime.Now.DayOfWeek);
                    Thread.Sleep(_throttle);
                    IncreaseThrottle();
                }
            }
            
        };
    }
}