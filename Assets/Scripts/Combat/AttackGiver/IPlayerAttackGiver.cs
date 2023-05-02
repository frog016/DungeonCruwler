public interface IPlayerAttackGiver : IAttackGiver
{
    public Attack CurrentAttack { get; set; }
    public CombatEntity Target { get; set; }
}