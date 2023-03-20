using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Configuration/CompositeStatsConfigurator", fileName = "CompositeStats class/race/other")]
public class CompositeStatsConfigurator : ScriptableStatsConfigurator<CompositeStatType>
{
    [SerializeField] private CompositeStatConfig _compositeStat;

    public IEnumerable<(CompositeStatType, (StatType, float)[])> InfluenceStats =>
        _compositeStat.Configs.Select(stat => (stat.CompositeStat, stat.InfluencingStats.ToArray()));
}