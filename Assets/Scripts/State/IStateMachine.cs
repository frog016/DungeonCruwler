public interface IStateMachine
{
    IState CurrentState { get; }
    void SetState(IState newState);
}