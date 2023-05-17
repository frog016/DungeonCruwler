using UnityEngine;

[RequireComponent(typeof(IAttackGiver))]
public class CombatEntity : DamageableUnit, ICombatEntity, ICombatStateMachine
{
    public Team Team { get; private set; }
    public bool Interrupted { get; set; }
    public IStats Stats { get; private set; }
    public ICompositeStats CompositeStats { get; private set; }
    public IInventory Inventory { get; private set; }
    public ICombatState Current { get; private set; }
    public IAttackGiver AttackGiver { get; private set; }
    
    private void Awake()
    {
        AttackGiver = GetComponent<IAttackGiver>();
    }

    public void Initialize(ICharacter character)
    {
        Stats = character.Stats;
        CompositeStats = character.CompositeStats;
        Inventory = character.Inventory;
        Team = character.Team;
        
        MaxHealth = CompositeStats.GetStat(CompositeStatType.Health);
        Health = MaxHealth;
    }

    public void SetState(ICombatState newState)
    {
        Current = newState;
        newState?.Enter(this);
    }
}