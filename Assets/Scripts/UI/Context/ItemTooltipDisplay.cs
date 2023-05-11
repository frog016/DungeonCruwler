using System;
using System.Linq;
using UnityEngine.EventSystems;
using Zenject;

public class ItemTooltipDisplay : TooltipDisplay
{
    private ItemTooltip _tooltip;
    private ItemTooltip[] _tooltips;

    [Inject]
    public void Constructor(ItemTooltip[] tooltips)
    {
        _tooltips = tooltips;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!TryGetContainer(eventData, out var itemUiContainer))
            return;

        _tooltip = GetTooltip(itemUiContainer.Item);
        _tooltip.Initialize(itemUiContainer.Item, itemUiContainer.Owner);
        _tooltip.Open();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _tooltip?.Close();
    }

    private bool TryGetContainer(PointerEventData eventData, out ItemUiContainer container)
    {
        UICell cell = null;
        _ = eventData.hovered.FirstOrDefault(obj => obj.TryGetComponent(out cell));
        container = cell?.Content;

        return container != null;
    }

    private ItemTooltip GetTooltip(IItem item)
    {
        foreach (var tooltip in _tooltips)
        {
            switch (tooltip)
            {
                case CommonItemTooltip when item.GetType() == typeof(ConsumableItem):
                    return tooltip;
                case EquipmentTooltip when item.GetType() == typeof(Equipment):
                    return tooltip;
                case WeaponTooltip when item.GetType() == typeof(Weapon):
                    return tooltip;
            }
        }

        throw new Exception($"Can't find tooltip for item {item}");
    }
}