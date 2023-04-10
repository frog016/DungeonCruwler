using UnityEngine;

public abstract class ScriptableEventAction<TEvent> : ScriptableObject, IEventAction<TEvent> where TEvent : IInteractableEvent
{
    [SerializeField] private int _threshold;
    [SerializeField] protected StatType _physicCheckStat;
    [SerializeField] protected StatType _magicCheckStat;
    [SerializeField] protected DamageTypeMapper _mapper;

    public abstract void Invoke(TEvent owner, ICharacter target);

    protected bool TryOvercomeThreshold(int value)
    {
        return value >= _threshold;
    }

    protected static void DealDamage(IDamageable character, int damage, int defense)
    {
        var totalDamage = Mathf.Max(damage - defense, 0);
        character.ApplyDamage(totalDamage);
        Debug.Log($"{character} applied {totalDamage}.");
    }

    protected int GetModifier(ICharacter character, DamageType type)
    {
        var stat = type == DamageType.Physical ? _physicCheckStat : _magicCheckStat;
        return character.Stats.GetStat(stat) / 2;
    }
}