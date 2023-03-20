using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ICharacter))]
public class RandomAttackGiver : MonoBehaviour, IAttackGiver
{
    [SerializeField] private CombatStateMachine _target;

    private Weapon _weapon;

    private void Start()
    {
        var character = GetComponent<ICharacter>();
        _weapon = character.Inventory.Weapon;
    }

    public bool TryGetAttack(out Attack attack, out CombatStateMachine target)
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