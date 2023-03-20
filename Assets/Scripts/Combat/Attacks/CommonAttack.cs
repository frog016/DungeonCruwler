using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Attack/Common", fileName = "CommonAttack")]
public class CommonAttack : Attack
{
    protected override void DealDamage<T>(T owner, T target, DamageArgs damage)
    {
        var targetDamageAbsorb = GetDamageAbsorb(target, damage.Type);
        var totalDamage = Mathf.FloorToInt(
            Math.Max(_damageMultiplier * damage.Damage - targetDamageAbsorb, 0));
        target.ApplyDamage(totalDamage);

        Debug.Log($"{owner} deal {totalDamage} damage to {target}.");
    }

    protected override void UseEffect<T>(T owner, T target, DamageArgs damage)
    {
    }
}