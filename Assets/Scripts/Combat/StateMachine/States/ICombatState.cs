public interface ICombatState
{
    void Enter(CombatEntity entity);
    void Next();
}