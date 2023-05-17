using System;
using System.Collections.Generic;

public class EquipmentWearer : IEquipmentWearer
{
    private readonly IInventory _inventory;
    private readonly Dictionary<EquipmentSlot, IEquipmentItem> _equipment;

    public EquipmentWearer(IInventory inventory)
    {
        _inventory = inventory;
        _equipment = new Dictionary<EquipmentSlot, IEquipmentItem>();
    }

    public void Equip(IEquipmentItem item)
    {
        if (_equipment.ContainsKey(item.Slot))
            throw new InvalidOperationException("Remove equipped item before equipping new.");

        _equipment.Add(item.Slot, item);
        _inventory.Remove(item);
    }

    public void Remove(IEquipmentItem item)
    {
        _equipment.Remove(item.Slot);
        _inventory.Add(item);
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