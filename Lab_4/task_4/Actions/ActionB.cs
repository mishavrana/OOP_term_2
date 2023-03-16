namespace Task_4;

public class ActionB: IAction
{
    public string Name { get; }

    public void Execute()
    {
        Console.WriteLine("Continue");
    }
    
    public ActionB(string name)
    {
        Name = name;
    }
}