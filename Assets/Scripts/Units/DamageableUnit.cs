using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageableUnit : MonoBehaviour, IDamageable
{
    public virtual int Health { get; protected set; }
    public virtual int MaxHealth { get; protected set; }
    public event Action<int> HealthChanged;
    public IEnumerable<IEffect> Effects => _effects;

    private readonly List<IEffect> _effects = new List<IEffect>();

    public virtual void ApplyDamage(int damage)
    {
        var exceptedHealth = Health - damage;
        Health = Mathf.Max(0, exceptedHealth);
        HealthChanged?.Invoke(Health);

        if (exceptedHealth <= 0)
            Die();
    }

    public void ApplyEffect(IEffect temporaryEffect)
    {
        _effects.Add(temporaryEffect);
    }

    public void RemoveEffect(IEffect temporaryEffect)
    {
        _effects.Remove(temporaryEffect);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}