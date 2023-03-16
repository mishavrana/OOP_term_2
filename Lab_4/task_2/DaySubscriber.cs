namespace Task_2;

public class DaySubscriber: Isubscriber
{
    public void Display(DateTime dateTime)
    {
        Console.WriteLine($"Day today: {dateTime.DayOfWeek}");
    }
}