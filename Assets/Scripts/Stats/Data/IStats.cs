using System;
using System.Collections.Generic;

public interface IStats<TStat> where TStat : Enum
{
    event Action<TStat, int> ValueChanged;
    void ChangeStat(TStat stat, int delta);
    int GetStat(TStat stat);
    IEnumerable<(TStat, int)> AllStats { get; }
}

public interface IStats : IStats<StatType>
{
}

public interface ICompositeStats : IStats<CompositeStatType>
{
}