using UnityEngine;

[RequireComponent(typeof(IAttackGiver))]
public class CombatStateMachine : DamageableUnit, ICharacter
{
    public IStats Stats { get; private set; }
    public ICompositeStats CompositeStats { get; private set; }
    public IInventory Inventory { get; private set; }

    public ICombatState CurrentState { get; private set; }
    public IAttackGiver AttackGiver { get; private set; }
    public bool Interrupted { get; set; }

    private void Awake()
    {
        AttackGiver = GetComponent<IAttackGiver>();
    }

    public void Initialize(IStats stats, ICompositeStats compositeStats, IInventory inventory)
    {
        Stats = stats;
        CompositeStats = compositeStats;
        Inventory = inventory;

        MaxHealth = CompositeStats.GetStat(CompositeStatType.Health);
        Health = MaxHealth;
    }

    public void SetState(ICombatState newState)
    {
        CurrentState = newState;
        newState?.Enter(this);
    }
}