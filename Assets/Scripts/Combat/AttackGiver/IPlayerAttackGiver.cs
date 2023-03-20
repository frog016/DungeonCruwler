public interface IPlayerAttackGiver : IAttackGiver
{
    public Attack CurrentAttack { get; set; }
    public CombatStateMachine Target { get; set; }
}