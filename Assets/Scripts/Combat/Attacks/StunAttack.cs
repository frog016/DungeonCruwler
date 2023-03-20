using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Attack/Stun", fileName = "StunAttack")]
public class StunAttack : Attack
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
        var effect = new StunEffect<T>(1, target);
        target.ApplyEffect(effect);
    }
}