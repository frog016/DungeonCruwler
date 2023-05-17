using System.Linq;
using UnityEngine;

public class Character : DamageableUnit, ICharacter
{
    [SerializeField] private Team _team;
    [SerializeField] private StatsConfigurator _baseStats;
    [SerializeField] private CompositeStatsConfigurator _compositeStats;
    [SerializeField] private ScriptableInventory _inventory;

    public Team Team => _team;
    public bool Interrupted { get; set; }
    public IStats Stats { get; private set; }
    public ICompositeStats CompositeStats { get; private set; }
    public IInventory Inventory => _inventory;
    public IEquipmentWearer EquipmentWearer { get; private set; }


    protected virtual void Awake()
    {
        Stats = new Stats(_baseStats.Stats);
        CompositeStats = new CompositeStats(Stats, _compositeStats.Stats, _compositeStats.InfluenceStats);
        EquipmentWearer = InitializeEquipment();

        MaxHealth = CompositeStats.GetStat(CompositeStatType.Health);
        Health = MaxHealth;
    }

    private IEquipmentWearer InitializeEquipment()
    {
        var equipmentWearer = new EquipmentWearer(Inventory);
        var items = Inventory.GetAll().ToArray();
        foreach (var item in items)
            if (item is IEquipmentItem equipment)
                equipmentWearer.Equip(equipment);
        
        return equipmentWearer;
    }
}