using System.Collections.Generic;

public interface ICombatEntity : ICharacter, ITargetable
{
    IAttackGiver AttackGiver { get; set; }
    void Initialize(ICharacter character);
}

public class CombatEntity : ICombatEntity
{
    public IAttackGiver AttackGiver { get; set; }
    public IEnumerable<IEffect> Effects => _character.Effects;
    public IStats Stats => _character.Stats;
    public ICompositeStats CompositeStats => _character.CompositeStats;
    public IInventory Inventory => _character.Inventory;
    public IEquipmentWearer EquipmentWearer => _character.EquipmentWearer;
    public Team Team => _character.Team;
    public int Health => _character.Health;
    public int MaxHealth => _character.MaxHealth;
    public bool Interrupted { get => _character.Interrupted; set => _character.Interrupted = value; }

    private ICharacter _character;

    public void Initialize(ICharacter character)
    {
        _character = character;
    }

    public void ApplyDamage(int damage)
    {
        _character.ApplyDamage(damage);
    }

    public void ApplyEffect(IEffect temporaryEffect)
    {
        _character.ApplyEffect(temporaryEffect);
    }

    public void RemoveEffect(IEffect temporaryEffect)
    {
        _character.RemoveEffect(temporaryEffect);
    }
}