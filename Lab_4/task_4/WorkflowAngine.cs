namespace Task_4;

public delegate void WorkflowEventHandler(List<IAction> action);

public class WorkflowAngine
{
    // Handles the status of execution
    public event WorkflowEventHandler ActionExecuted;
    
    // Handles the start
    public event Action? StartEction;
    
    // Handles the continiu event
    public event Action? ContinueEction;
    
    // Handles the end event
    public event Action? EndEction;

    private WorkflowStateHandler _stateHandler = new WorkflowStateHandler();

    public void Start(List<IAction> actions)
    {
        foreach (var ection in actions)
        {
            StartEction += ection.Execute;
        }
        StartEction.Invoke();
        ActionExecuted.Invoke(actions);
    }

    public void Continue(List<IAction> actions)
    {
        foreach (var ection in actions)
        {
            ContinueEction += ection.Execute;
        }
        ContinueEction.Invoke();
        ActionExecuted.Invoke(actions);
    }
    
    public void End(List<IAction> actions)
    {
        foreach (var ection in actions)
        {
            EndEction += ection.Execute;
        }
        EndEction.Invoke();
        ActionExecuted.Invoke(actions);
    }

    private void OnActionExecuted(List<IAction> actions)
    {
        ActionExecuted?.Invoke(actions);
    }
}