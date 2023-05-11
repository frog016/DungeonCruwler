using System;
using System.Linq;
using UnityEngine.EventSystems;

public class ItemTooltipDisplay : TooltipDisplay
{
    private ItemTooltip _tooltip;
    private ItemTooltip[] _tooltips;

    public void Constructor(ItemTooltip[] tooltips)
    {
        _tooltips = tooltips;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        var pointerDrag = eventData.pointerDrag;
        if (pointerDrag == null || pointerDrag.TryGetComponent<ItemUiContainer>(out var itemUiContainer))
            return;

        _tooltip = GetTooltip(itemUiContainer.Item);
        _tooltip.Initialize(itemUiContainer.Item, itemUiContainer.Owner);
        _tooltip.Open();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _tooltip.Close();
    }

    private ItemTooltip GetTooltip(IItem item)
    {
        var tooltip = _tooltips.FirstOrDefault(t => t.GetType() == item.GetType());
        if (tooltip != null)
            return tooltip;

        throw new Exception($"Can't find tooltip for item {item}");
    }
}