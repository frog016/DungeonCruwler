using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableStatsConfigurator<TStat> : ScriptableObject where TStat : Enum
{
    [SerializeField] private StatsConfig<TStat> _config;

    public IEnumerable<(TStat, int)> Stats => _config.Stats;
}