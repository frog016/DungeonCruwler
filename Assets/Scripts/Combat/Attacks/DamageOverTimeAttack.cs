using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Attack/DoT", fileName = "DamageOverTimeAttack")]
public class DamageOverTimeAttack : Attack
{
    protected override void DealDamage<T>(T owner, T target, DamageArgs damage)
    {
        var targetDamageAbsorb = GetDamageAbsorb(target, damage.Type);
        var totalDamage = Math.Max(_damageMultiplier * damage.Damage - targetDamageAbsorb, 0);
        target.ApplyDamage(Mathf.FloorToInt(totalDamage));

        Debug.Log($"{owner} deal {Mathf.FloorToInt(totalDamage)} damage to {target}.");
    }

    protected override void UseEffect<T>(T owner, T target, DamageArgs damage)
    {
        const float multiplier = 0.25f;
        var duration = damage.Damage / 2;
        var effect = new DoTEffect(duration, Mathf.FloorToInt(multiplier * damage.Damage), target);
        target.ApplyEffect(effect);
    }
}