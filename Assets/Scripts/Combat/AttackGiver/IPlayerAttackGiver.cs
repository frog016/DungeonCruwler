public interface IPlayerAttackGiver : IAttackGiver
{
    public Attack CurrentAttack { get; set; }
    public CombatEntityBehaviour Target { get; set; }
}