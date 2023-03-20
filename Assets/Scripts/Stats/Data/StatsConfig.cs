using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class StatsConfig<TStat> where TStat : Enum
{
    [SerializeField] private StatInfo[] _modificationStats;

    public IEnumerable<(TStat, int)> Stats => _modificationStats.Select(statInfo => (statInfo.StatType, statInfo.Value));

    [Serializable]
    public struct StatInfo
    {
        [SerializeField] private TStat _statType;
        [SerializeField] private int _value;

        public TStat StatType => _statType;
        public int Value => _value;
    }
}