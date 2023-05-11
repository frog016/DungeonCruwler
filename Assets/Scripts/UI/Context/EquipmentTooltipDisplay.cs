using UnityEngine;

//[RequireComponent(typeof(EquipmentCell))]
public class EquipmentTooltipDisplay : TooltipDisplay<EquipmentTooltip>
{
    //private EquipmentCell _equipmentCell;

    protected override void Awake()
    {
    //    _equipmentCell = GetComponent<EquipmentCell>();
    }

    protected override void InitializeTooltip(EquipmentTooltip tooltip)
    {
        //var equipment = _equipmentCell.Content.GetComponent<ItemView>().Item as Equipment;
        //tooltip.Initialize(equipment.name, equipment, );
    }
}