using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Attack/Ignore Absorb", fileName = "IgnoreAbsorbAttack")]
public class IgnoreAbsorbAttack : Attack
{
    protected override void DealDamage<T>(T owner, T target, DamageArgs damage)
    {
        var targetDamageAbsorb = IsThresholdExceeded(damage.Damage, damage.Threshold) ? 0 : GetDamageAbsorb(target, damage.Type);
        var totalDamage = Math.Max(_damageMultiplier * damage.Damage - targetDamageAbsorb, 0);
        target.ApplyDamage(Mathf.FloorToInt(totalDamage));

        Debug.Log($"{owner} deal {Mathf.FloorToInt(totalDamage)} damage to {target}.");
    }

    protected override void UseEffect<T>(T owner, T target, DamageArgs damage)
    {
    }
}