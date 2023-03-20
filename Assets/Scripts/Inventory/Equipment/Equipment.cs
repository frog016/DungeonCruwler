using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Default equipment", fileName = "Equipment")]
public class Equipment : ScriptableObject
{
    [SerializeField] private EquipmentSlot _slot;
    [SerializeField] private StatsConfig<StatType> _additionalStats;
    [SerializeField] private StatsConfig<CompositeStatType> _additionalCompositeStats;

    public void Equip(IStatsUser statsUser)
    {
        const int sign = 1;
        ChangeStats(_additionalStats, statsUser.Stats, sign);
        ChangeStats(_additionalCompositeStats, statsUser.CompositeStats, sign);
    }

    public void Remove(IStatsUser statsUser)
    {
        const int sign = -1;
        ChangeStats(_additionalStats, statsUser.Stats, sign);
        ChangeStats(_additionalCompositeStats, statsUser.CompositeStats, sign);
    }

    private static void ChangeStats<TStat>(StatsConfig<TStat> config, IStats<TStat> stats, int sign) where TStat : Enum
    {
        foreach (var (stat, value) in config.Stats)
            stats.ChangeStat(stat, Math.Sign(sign) * value);
    }
}