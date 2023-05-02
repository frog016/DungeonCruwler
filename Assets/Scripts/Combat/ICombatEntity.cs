public interface ICombatEntity : ICharacter, ITargetable
{
    IAttackGiver AttackGiver { get; }
    void Initialize(ICharacter character);
}