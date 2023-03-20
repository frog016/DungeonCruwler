using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageableUnit : MonoBehaviour, IDamageable
{
    public int Health { get; protected set; }
    public int MaxHealth { protected set; get; }
    public event Action<int> HealthChanged;
    public IEnumerable<ITickableEffect> Effects => _effects;

    private readonly List<ITickableEffect> _effects = new List<ITickableEffect>();

    public void ApplyDamage(int damage)
    {
        var exceptedHealth = Health - damage;
        Health = Mathf.Max(0, exceptedHealth);
        HealthChanged?.Invoke(Health);

        if (exceptedHealth <= 0)
            Die();
    }

    public void ApplyEffect(ITickableEffect tickableEffect)
    {
        _effects.Add(tickableEffect);
    }

    public void RemoveEffect(ITickableEffect tickableEffect)
    {
        _effects.Remove(tickableEffect);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}