using UnityEngine;

public class UIEquipmentCell : UICell
{
    [SerializeField] private EquipmentSlot _slot;

    public EquipmentSlot Slot => _slot;
}