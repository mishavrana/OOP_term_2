namespace Task_4;

public class ActionA: IAction
{
    public string Name { get; }

    public void Execute()
    {
        Console.WriteLine("Start");
    }

    public ActionA(string name)
    {
        Name = name;
    }
}