using System.Linq;
using UnityEngine;

public class SimpleStats : MonoBehaviour, IStatsUser
{
    [SerializeField] private StatValuePair<StatType>[] _stats;
    [SerializeField] private StatValuePair<CompositeStatType>[] _compositeStats;
    [SerializeField] private CompositeStatConfig _config;

    public IStats Stats { get; private set; }
    public ICompositeStats CompositeStats { get; private set; }

    private void Awake()
    {
        Stats = new Stats(_stats.Select(stat => (stat.Stat, stat.Value)));

        var influencingStats = _config
            .Configs
            .Select(config => (config.CompositeStat, config.InfluencingStats.ToArray()));
        CompositeStats = new CompositeStats(Stats, _compositeStats.Select(stat => (stat.Stat, stat.Value)), influencingStats);
    }
}