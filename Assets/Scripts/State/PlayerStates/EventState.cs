public class EventState : IState
{
    public void Enter<T>(T stateMachine) where T : IStateMachine
    {
    }

    public void Next<T>(T stateMachine) where T : IStateMachine
    {
    }
}