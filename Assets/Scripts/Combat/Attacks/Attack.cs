using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [SerializeField] protected float _damageMultiplier = 1f;
    [SerializeField] protected DamageTypeMapper _mapper;

    public void Use<T>(T owner, T target) where T : ICharacter
    {
        var weapon = owner.Inventory.Weapon;
        var maxDamage = weapon.GetMaximumDamage(owner);
        var damage = Dice.Roll(maxDamage);
        Debug.Log($"{owner} rolled {damage} damage from (0-{maxDamage}).");

        var damageArgs = new DamageArgs(damage, weapon.GetAttackData(this).DamageThreshold, weapon.DamageType);
        Debug.Log($"Threshold is {damageArgs.Threshold}.");

        DealDamage(owner, target, damageArgs);
        if (IsThresholdExceeded(damage, damageArgs.Threshold))
        {
            Debug.Log("Threshold is exceeded. Effect will be applied.");
            UseEffect(owner, target, damageArgs);
        }
    }

    protected abstract void DealDamage<T>(T owner, T target, DamageArgs damage) where T : ICharacter;
    protected abstract void UseEffect<T>(T owner, T target, DamageArgs damage) where T : ICharacter;

    protected int GetDamageAbsorb<T>(T statUser, DamageType type) where T : ICharacter
    {
        var absorbType = _mapper.GetValue(type);
        return statUser.CompositeStats.GetStat(absorbType);
    }

    protected bool IsThresholdExceeded(int damage, int threshold)
    {
        return damage >= threshold;
    }

    protected readonly struct DamageArgs
    {
        public readonly int Damage;
        public readonly int Threshold;
        public readonly DamageType Type;

        public DamageArgs(int damage, int threshold, DamageType type)
        {
            Damage = damage;
            Threshold = threshold;
            Type = type;
        }
    }
}