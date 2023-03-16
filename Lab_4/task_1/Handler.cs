namespace Task_1;

public class Handler
{
    public delegate void DateTimeDelegate(object sender, EventArgs eventArgs);

    public event DateTimeDelegate? DateTimeEvent;

    public void Run()
    {
        if (DateTimeEvent != null)
        {
            DateTimeEvent.Invoke(this, EventArgs.Empty);
        }
    }
}