using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour, IModifierApplier
{
    public IStats Stats { get; private set; }

    private List<IStatsModifier> _modifiers;

    public void Constructor(IStats stats, IStatsModifier[] permanentModifiers)
    {
        Stats = stats;
        _modifiers = permanentModifiers.ToList();
        foreach (var permanentModifier in _modifiers)
            Apply(permanentModifier);
    }

    public void Apply(IStatsModifier modifier)
    {
        modifier.Modify(Stats);
        _modifiers.Add(modifier);
    }

    public void Undo(IStatsModifier modifier)
    {
        _modifiers.Remove(modifier);
    }
}