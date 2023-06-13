using System.Collections.Generic;

public interface IEquipmentWearer
{
    void Equip(IEquipmentItem item);
    void Remove(IEquipmentItem item);
    bool TryGetItem(EquipmentSlot slot, out IEquipmentItem item);
    IEnumerable<IEquipmentItem> GetAll();
}