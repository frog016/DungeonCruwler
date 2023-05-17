using System;
using System.Collections.Generic;
using System.Linq;

public static class StatsExtensions
{
    public static IEnumerable<StatValuePair<TStat>> ToValuePairs<TStat>(this IEnumerable<(TStat, int)> collection)
        where TStat : Enum
    {
        return collection.Select(tuple => new StatValuePair<TStat>(tuple.Item2, tuple.Item1));
    }

    public static IEnumerable<StatValuePair<Enum>> GetAllStats(this IStatsUser user)
    {
        return user.Stats.AllStats
            .Select(stat => new StatValuePair<Enum>(stat.Item2, stat.Item1))
            .Concat(user.CompositeStats.AllStats
                .Select(stat => new StatValuePair<Enum>(stat.Item2, stat.Item1)));
    }
}