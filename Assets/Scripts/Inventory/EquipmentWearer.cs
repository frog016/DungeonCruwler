using System;
using System.Collections.Generic;

public class EquipmentWearer : IEquipmentWearer
{
    private readonly Dictionary<EquipmentSlot, IEquipmentItem> _equipment;

    public void Equip(IEquipmentItem item)
    {
        if (_equipment.ContainsKey(item.Slot))
            throw new InvalidOperationException("Remove equipped item before equipping new.");

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

    public IEnumerable<IEquipmentItem> GetAll()
    {
        return _equipment.Values;
    }
}