public interface IAttackGiver
{
    bool TryGetAttack(out Attack attack, out CombatEntityBehaviour target);
}