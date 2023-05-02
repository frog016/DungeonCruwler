public interface IAttackGiver
{
    bool TryGetAttack(out Attack attack, out CombatEntity target);
}