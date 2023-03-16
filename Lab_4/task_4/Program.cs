namespace Task_4;

class Program
{
    static WorkflowAngine engine = new WorkflowAngine();

    static IAction actionA = new ActionA("Start action");
    static IAction actionB = new ActionB("Continue action");
    static IAction actionC = new ActionC("Finish action");

    private static List<IAction> startActions = new List<IAction>() { actionA};
    private static List<IAction> continueActions = new List<IAction>() { actionB };
    private static List<IAction> endActions = new List<IAction>() { actionC };
    
    static void Main(string[] args)
    {
        engine.ActionExecuted += OnEctionExecuted;
        
        engine.Start(startActions);
        engine.Continue(continueActions);
        engine.End(endActions);
        
    }

    static void OnEctionExecuted(List<IAction> actions)
    {
        foreach (var action in actions)
        {
            Console.WriteLine($"{action.Name} added");
        }
    }
}