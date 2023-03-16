namespace Task_4;

public class ActionC: IAction
{
    public string Name { get; }

    public void Execute()
    {
        Console.WriteLine("Finish");
    }
    
    public ActionC(string name)
    {
        Name = name;
    }
}