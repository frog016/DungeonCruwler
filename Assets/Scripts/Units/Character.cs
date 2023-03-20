using UnityEngine;

public class Character : DamageableUnit, ICharacter
{
    [SerializeField] private StatsConfigurator _baseStats;
    [SerializeField] private CompositeStatsConfigurator _compositeStats;
    [SerializeField] private Inventory _inventory;

    public bool Interrupted { get; set; }
    public IStats Stats { get; private set; }
    public ICompositeStats CompositeStats { get; private set; }
    public IInventory Inventory => _inventory;

    protected virtual void Awake()
    {
        Stats = new Stats(_baseStats.Stats);
        CompositeStats = new CompositeStats(Stats, _compositeStats.Stats, _compositeStats.InfluenceStats);
        MaxHealth = CompositeStats.GetStat(CompositeStatType.Health);
        Health = MaxHealth;
    }
}