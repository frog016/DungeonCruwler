public interface IState
{
    void Enter<T>(T stateMachine) where T : IStateMachine;
    void Next<T>(T stateMachine) where T : IStateMachine;
}
