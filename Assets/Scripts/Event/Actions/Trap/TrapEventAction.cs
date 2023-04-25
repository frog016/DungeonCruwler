using UnityEngine;

public abstract class TrapEventAction : ScriptableEventAction<TrapEvent>
{
    [SerializeField] protected StatType _physicCheckStat;
    [SerializeField] protected StatType _magicCheckStat;
    [SerializeField] protected DamageTypeMapper _mapper;

    protected bool TryOvercomeThreshold(TrapData data, ICharacter target)
    {
        var avoidValue = Dice.RollD20() + GetModifier(target, data.DamageType);
        var threshold = data.ComplexityClass;

        Debug.Log($"{target} rolled {avoidValue}.");
        return avoidValue >= threshold;
    }

    protected int GetModifier(ICharacter character, DamageType type)
    {
        var stat = type == DamageType.Physical ? _physicCheckStat : _magicCheckStat;
        return character.Stats.GetStat(stat) / 2;
    }

    protected static void DealDamage(IDamageable character, int damage, int defense)
    {
        var totalDamage = Mathf.Max(damage - defense, 0);
        character.ApplyDamage(totalDamage);
        Debug.Log($"{character} applied {totalDamage} damage.");
    }
}