namespace Task_4;

public class WorkflowStateHandler
{
    private IAction _action;

    public void Start(IAction action)
    {
        // Here can be additional code to start a workflow and then implement action
        _action = action;
        _action.Execute();
    }

    public void Continue(IAction action)
    {
        _action = action;
        _action.Execute();
    }
    
    public void Finish(IAction action)
    {
        _action = action;
        _action.Execute();
        // Here can be additional code to finish workflow and implement
    }
}