using UnityEngine;

public class DoTEffect<T> : TemporaryEffect<T> where T : ICharacter
{
    private readonly int _damage;

    public DoTEffect(int duration, float damage, T target) : base(duration, target)
    {
        _damage = Mathf.FloorToInt(damage);
    }

    protected override void UseEffect()
    {
        _target.ApplyDamage(_damage);
        Debug.Log($"{_target} applied {_damage} damage from DoT tick.");
    }

    protected override void End()
    {
    }
}