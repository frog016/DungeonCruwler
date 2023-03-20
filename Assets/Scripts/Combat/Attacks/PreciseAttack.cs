using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Attack/Precise", fileName = "PreciseAttack")]
public class PreciseAttack : Attack
{
    protected override void DealDamage<T>(T owner, T target, DamageArgs damage)
    {
    }

    protected override void UseEffect<T>(T owner, T target, DamageArgs damage)
    {
        var targetDamageAbsorb = GetDamageAbsorb(target, damage.Type);
        var totalDamage = Math.Max(_damageMultiplier * damage.Damage - targetDamageAbsorb, 0);
        target.ApplyDamage(Mathf.FloorToInt(totalDamage));

        Debug.Log($"{owner} deal {Mathf.FloorToInt(totalDamage)} damage to {target}.");
    }
}