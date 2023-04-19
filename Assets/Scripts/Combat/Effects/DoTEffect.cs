using UnityEngine;

public class DoTEffect : ITickableEffect
{
    public int Duration { get; set; }

    private readonly int _damage;
    private readonly ICharacter _target;

    public DoTEffect(int duration, int damage, ICharacter target)
    {
        Duration = duration;
        _damage = damage;
        _target = target;
    }

    public void Apply()
    {
        _target.ApplyDamage(_damage);
        Debug.Log($"{_target} applied {_damage} damage from DoT tick.");
    }
}