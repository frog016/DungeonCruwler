using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ICharacter))]
public class RandomAttackGiver : MonoBehaviour, IAttackGiver
{
    [SerializeField] private CombatEntity _target;

    private Weapon _weapon;

    private void Start()
    {
        var character = GetComponent<ICharacter>();
        _weapon = character.GetWeapon();
    }

    public bool TryGetAttack(out Attack attack, out CombatEntity target)
    {
        attack = GetRandomAttack();
        target = _target;
        return true;
    }

    private Attack GetRandomAttack()
    {
        var attacks = _weapon.Attacks.ToArray();
        var index = Random.Range(0, attacks.Length);
        return attacks[index];
    }
}