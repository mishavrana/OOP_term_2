namespace Task_4;

public interface IAction
{
    public string Name { get; }
    public void Execute();
}