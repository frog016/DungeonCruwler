using UnityEngine;

public class Character : MonoBehaviour, IModifierApplier
{
    public IStats Stats { get; private set; }

    private IStatsModifier[] _modifiers;

    public void Constructor(IStats stats, IStatsModifier[] permanentModifiers)
    {
        Stats = stats;
        _modifiers = permanentModifiers;
        foreach (var permanentModifier in _modifiers)
            Apply(permanentModifier);
    }

    public void Apply(IStatsModifier modifier)
    {
        modifier.Modify(Stats);
    }
}