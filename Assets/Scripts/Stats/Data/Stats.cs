using System;
using System.Collections.Generic;
using System.Linq;

public class Stats : IStats
{
    public event Action<StatType, int> ValueChanged;

    private readonly Dictionary<StatType, int> _stats;

    public Stats(IEnumerable<(StatType, int)> stats)
    {
        _stats = stats.ToDictionary(key => key.Item1, value => value.Item2);
    }

    public void ChangeStat(StatType statType, int delta)
    {
        _stats[statType] += delta;
        ValueChanged?.Invoke(statType, _stats[statType]);
    }

    public int GetStat(StatType statType)
    {
        return _stats[statType];
    }

    public IEnumerable<(StatType, int)> AllStats => _stats.Select(pair => (pair.Key, GetStat(pair.Key)));
}