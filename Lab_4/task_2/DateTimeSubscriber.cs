namespace Task_2;

public class DateTimeSubscriber: Isubscriber
{
    public void Display(DateTime dateTime)
    {
        Console.WriteLine($"Date time: {dateTime}");
    }
}