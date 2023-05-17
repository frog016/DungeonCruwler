using System.Linq;
using UnityEngine.EventSystems;
using Zenject;

public class AttackTooltipDisplay : TooltipDisplay
{
    private AttackTooltip _tooltip;

    [Inject]
    public void Constructor(AttackTooltip tooltip)
    {
        _tooltip = tooltip;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!TryGetAttackButton(eventData, out var attackButton))
            return;

        var attack = attackButton.Attack;
        var weapon = attackButton.Owner.GetWeapon();
        _tooltip.Initialize(attack.name, weapon.GetMaximumDamage(attackButton.Owner), "", 0);
        _tooltip.Open();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _tooltip?.Close();
    }

    private bool TryGetAttackButton(PointerEventData eventData, out AttackButton attackButton)
    {
        _ = eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out AttackButton button);
        attackButton = button;

        return attackButton != null;
    }
}