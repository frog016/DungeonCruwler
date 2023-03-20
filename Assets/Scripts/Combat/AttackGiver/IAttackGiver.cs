public interface IAttackGiver
{
    bool TryGetAttack(out Attack attack, out CombatStateMachine target);
}