using System.Collections.Generic;

public class EquipmentWearer : IEquipmentWearer
{
    private readonly Dictionary<EquipmentSlot, IEquipmentItem> _equipment;

    public void Equip(IEquipmentItem item)
    {
        if (_equipment.TryGetValue(item.Slot, out var equippedItem))
            Remove(equippedItem);

        _equipment.Add(item.Slot, item);
    }

    public void Remove(IEquipmentItem item)
    {
        _equipment.Remove(item.Slot);
    }

    public bool TryGetItem(EquipmentSlot slot, out IEquipmentItem item)
    {
        return _equipment.TryGetValue(slot, out item);
    }
}