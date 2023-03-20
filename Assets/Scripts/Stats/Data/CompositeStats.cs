using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeStats : ICompositeStats
{
    public event Action<CompositeStatType, int> ValueChanged;

    private readonly IStats _baseStats;
    private readonly Dictionary<CompositeStatType, int> _ownValues;
    private readonly Dictionary<CompositeStatType, (StatType, float)[]> _influenceStats;

    public CompositeStats(IStats baseStats, 
        IEnumerable<(CompositeStatType, int)> defaultValues, 
        IEnumerable<(CompositeStatType, (StatType, float)[])> influenceStats)
    {
        _baseStats = baseStats;
        _ownValues = defaultValues.ToDictionary(key => key.Item1, value => value.Item2);
        _influenceStats = influenceStats.ToDictionary(key => key.Item1, value => value.Item2);
    }

    public void ChangeStat(CompositeStatType statType, int delta)
    {
        _ownValues[statType] += delta;
        ValueChanged?.Invoke(statType, _ownValues[statType]);
    }

    public int GetStat(CompositeStatType statType)
    {
        return _ownValues[statType] +
               _influenceStats[statType]
                   .Select(influenceStat => _baseStats.GetStat(influenceStat.Item1) * influenceStat.Item2)
                   .Select(Mathf.FloorToInt)
                   .Sum();
    }

    public IEnumerable<(CompositeStatType, int)> AllStats => _ownValues.Select(pair => (pair.Key, GetStat(pair.Key)));
}