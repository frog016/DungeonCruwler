public interface ICombatState
{
    void Enter(CombatEntityBehaviour entity);
    void Next();
}