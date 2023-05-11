using UnityEngine;

[RequireComponent(typeof(AttackButton))]
public class AttackTooltipDisplay : TooltipDisplay<AttackTooltip>
{
    private AttackButton _attackButton;

    protected override void Awake()
    {
        base.Awake();
        _attackButton = GetComponent<AttackButton>();
    }

    protected override void InitializeTooltip(AttackTooltip tooltip)
    {
        var attack = _attackButton.Attack;
        var character = _attackButton.Owner;
        var weapon = character.GetWeapon();
        tooltip.Initialize(attack.name, weapon.GetMaximumDamage(character), "", 0);
    }
}