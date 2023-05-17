using System;
using UnityEngine;

public abstract class NegativeEventAction : ScriptableEventAction
{
    [SerializeField] protected StatType _physicStatToCheck;
    [SerializeField] protected StatType _magicStatToCheck;
    [SerializeField] private DamageTypeMapper _mapper;

    protected bool TryOvercomeThreshold(HiddenEventBehaviour owner, ICharacter target)
    {
        var avoidValue = Dice.RollD20() + GetModifier(target, owner.DamageType);
        var threshold = owner.ComplexityClass;
        return avoidValue >= threshold;
    }

    public float CalculateChance(HiddenEventBehaviour owner, ICharacter target)
    {
        var maxRoll = Dice.D20 + GetModifier(target, owner.DamageType);
        return (float)owner.ComplexityClass / maxRoll;
    }

    protected (int, int) GetEventParameters(HiddenEventBehaviour owner, IStatsUser target)
    {
        var damage = owner.Damage;

        var defenseType = _mapper.GetValue(owner.DamageType);
        var defense = target.CompositeStats.GetStat(defenseType);

        return ValueTuple.Create(damage, defense);
    }

    protected void DealDamage(ICharacter target, int damage, int defense)
    {
        var totalDamage = Mathf.Max(0, damage - defense);
        target.ApplyDamage(totalDamage);
    }

    private int GetModifier(IStatsUser character, DamageType type)
    {
        var stat = type == DamageType.Physical ? _physicStatToCheck : _magicStatToCheck;
        return character.Stats.GetStat(stat) / 2;
    }
}