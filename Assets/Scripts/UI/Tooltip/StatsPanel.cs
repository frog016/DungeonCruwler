using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private OrderedStatView<StatType>[] _statViews;
    [SerializeField] private OrderedStatView<CompositeStatType>[] _compositeStatViews;

    [Inject]
    public void Constructor(ICharacter statsUser)
    {
        InitializeOrderedStats(statsUser.CompositeStats, _compositeStatViews);
        InitializeOrderedStats(statsUser.Stats, _statViews);
    }

    private static void InitializeOrderedStats<TStat>(IStats<TStat> stats, IEnumerable<OrderedStatView<TStat>> views) where TStat : Enum
    {
        var statsViewPairs = MapStatView(stats, views);
        foreach (var (statValuePair, view) in statsViewPairs)
            view.Initialize(statValuePair.Item2);
    }

    private static IEnumerable<Tuple<(TStat, int), OrderedStatView<TStat>>> MapStatView<TStat>(IStats<TStat> stats,
        IEnumerable<OrderedStatView<TStat>> views) where TStat : Enum
    {
        var dictionary = stats.AllStats.ToDictionary(key => key.Item1, value => value);
        foreach (var orderedStatView in views)
            yield return Tuple.Create(dictionary[orderedStatView.Stat], orderedStatView);
    }
}
