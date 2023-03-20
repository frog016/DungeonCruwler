public interface ICombatState
{
    void Enter(CombatStateMachine stateMachine);
    void Next();
}