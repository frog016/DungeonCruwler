using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentCell : UIElementCell
{
    [SerializeField] private EquipmentSlot _slot;
    [SerializeField] private InventoryUI _inventoryUi;

    public EquipmentSlot Slot => _slot;

    protected override bool TryDrop(PointerEventData eventData)
    {
        if (!Element.TryGetComponent<ItemView>(out var view) || view.Item is not IEquipmentItem equipmentItem ||
            equipmentItem.Slot != _slot) 
            return false;

        _inventoryUi.Wearer.Equip(equipmentItem);
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (!Element.TryGetComponent<ItemView>(out var view) || view.Item is not IEquipmentItem equipmentItem)
            return;

        _inventoryUi.Wearer.Remove(equipmentItem);
    }
}