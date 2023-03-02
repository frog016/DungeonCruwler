using System;
using System.Collections.Generic;

public class Stats : IStats
{
    public event Action<Stat, float> ValueChanged; 

    private Dictionary<Stat, float> _stats;

    public void ChangeStatByValue(Stat stat, float delta)
    {
        _stats[stat] += delta;
        ValueChanged?.Invoke(stat, _stats[stat]);
    }

    public float GetStatValue(Stat stat)
    {
        return _stats[stat];
    }
}