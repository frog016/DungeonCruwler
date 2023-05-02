public interface IStateMachine<TState>
{
    TState Current { get; }
    void SetState(TState newState);
}