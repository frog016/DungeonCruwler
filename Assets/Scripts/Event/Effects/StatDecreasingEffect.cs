using UnityEngine;

[CreateAssetMenu(menuName = "Event/Trap/Effects/StatDecreasing", fileName = "StatDecreasingEffect")]
public class StatDecreasingEffect : ScriptableTemporaryEffect
{
    [SerializeField] private StatValuePair<StatType>[] _statDebuffs;
    [SerializeField] private StatValuePair<CompositeStatType>[] _compositeStatDebuffs;

    public override void Apply()
    {
        base.Apply();
        _statDebuffs.Apply(pair => Target.Stats.ChangeStat(pair.Stat, -pair.Value));
        _compositeStatDebuffs.Apply(pair => Target.CompositeStats.ChangeStat(pair.Stat, -pair.Value));
    }

    public override void Remove()
    {
        base.Remove();
        _statDebuffs.Apply(pair => Target.Stats.ChangeStat(pair.Stat, pair.Value));
        _compositeStatDebuffs.Apply(pair => Target.CompositeStats.ChangeStat(pair.Stat, pair.Value));
    }
}