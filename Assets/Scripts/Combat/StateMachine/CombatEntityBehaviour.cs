using UnityEngine;

[RequireComponent(typeof(IAttackGiver))]
public class CombatEntityBehaviour : DamageableUnit, ICombatEntity, ICombatStateMachine
{
    public IStats Stats => _combatEntity.Stats;
    public ICompositeStats CompositeStats => _combatEntity.CompositeStats;
    public IInventory Inventory => _combatEntity.Inventory;
    public IEquipmentWearer EquipmentWearer => _combatEntity.EquipmentWearer;
    public Team Team => _combatEntity.Team;
    public bool Interrupted
    {
        get => _combatEntity.Interrupted;
        set => _combatEntity.Interrupted = value;
    }
    public ICombatState Current { get; private set; }
    public IAttackGiver AttackGiver { get; set; }
    public override int Health => _combatEntity.Health;
    public override int MaxHealth => _combatEntity.MaxHealth;

    private ICombatEntity _combatEntity;

    private void Awake()
    {
        AttackGiver = GetComponent<IAttackGiver>();
    }

    public void Initialize(ICharacter character)
    {
        _combatEntity = new CombatEntity();
        _combatEntity.AttackGiver = AttackGiver;
        _combatEntity.Initialize(character);
    }

    public override void ApplyDamage(int damage)
    {
        _combatEntity.ApplyDamage(damage);
    }

    public void SetState(ICombatState newState)
    {
        Current = newState;
        newState?.Enter(this);
    }
}