using System;
using System.Collections.Generic;

public class Stats : IStats
{
    public event Action<Stat, float> ValueChanged; 

    private readonly Dictionary<Stat, float> _stats;

    public Stats()
    {
        _stats = CreateEmptyStatValues();
    }

    public void ChangeStatByValue(Stat stat, float delta)
    {
        _stats[stat] += delta;
        ValueChanged?.Invoke(stat, _stats[stat]);
    }

    public float GetStatValue(Stat stat)
    {
        return _stats[stat];
    }

    private static Dictionary<Stat, float> CreateEmptyStatValues()
    {
        var stats = new Dictionary<Stat, float>();
        foreach (var enumName in Enum.GetNames(typeof(Stat)))
            if (Enum.TryParse<Stat>(enumName, out var stat))
                stats.Add(stat, 0);

        return stats;
    }
}