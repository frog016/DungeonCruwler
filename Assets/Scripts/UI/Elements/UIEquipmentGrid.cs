using System;
using System.Linq;

public class UIEquipmentGrid : UIGrid<UIEquipmentCell>
{
    public override UIEquipmentCell[] GetEmptyCells(ItemView content)
    {
        if (content.Item is not IEquipmentItem equipment)
            throw new ArgumentException($"Invalid item. {content.Item} can't be placed in equipment slot.");

        return TryGetCellForTwoHandedEquipment(equipment, out var emptyCells) ?
            emptyCells : 
            new UIEquipmentCell[] { Cells.First(cell => cell.Slot == equipment.Slot) };
    }

    private bool TryGetCellForTwoHandedEquipment(IEquipmentItem equipment, out UIEquipmentCell[] emptyCells)
    {
        emptyCells = null;
        if (equipment.Slot != EquipmentSlot.TwoHand) 
            return false;

        emptyCells = Cells
            .Where(cell => cell.Slot is EquipmentSlot.RightHand or EquipmentSlot.LeftHand)
            .ToArray();
        return true;

    }
}