using System;
using System.Linq;
using UnityEngine;

public class UIInventoryPanel : UIPanel
{
    [SerializeField] private UIItemGrid _itemGrid;
    [SerializeField] private UIEquipmentGrid _equipmentGrid;
    [SerializeField] private ItemView _itemViewPrefab;

    public ICharacter Owner { get; private set; }

    public void Constructor(ICharacter character)
    {
        Owner = character;
    }

    private void Start()
    {
        InitializeItemGrid(Owner.Inventory);
        InitializeEquipmentGrid(Owner.EquipmentWearer);
    }

    private void InitializeItemGrid(IInventory inventory)
    {
        foreach (var item in inventory.GetAll())
        {
            var itemView = CreateItemView(item);
            _itemGrid.AddContent(itemView);
        }
    }

    private void InitializeEquipmentGrid(IEquipmentWearer equipmentWearer)
    {
        foreach (var equipment in equipmentWearer.GetAll())
        {
            var itemView = CreateItemView(equipment);
            if (TryInitializeTwoHanded(itemView, equipment))
                continue;

            _equipmentGrid.AddContent(itemView);
        }
    }

    private bool TryInitializeTwoHanded(ItemView itemView, IEquipmentItem equipment)
    {
        if (equipment.Slot != EquipmentSlot.TwoHand) 
            return false;

        var itemViewCopy = CreateItemView(equipment);
        var viewCellPairs = new ItemView[] { itemView, itemViewCopy }
            .Zip(_equipmentGrid.GetEmptyCells(itemView), Tuple.Create);

        foreach (var (view, cell) in viewCellPairs)
            _equipmentGrid.AddContentTo(view, cell);

        return true;

    }

    private ItemView CreateItemView(IItem item)
    {
        var itemView = Instantiate(_itemViewPrefab);
        itemView.Initialize(item.ToString(), item);
        return itemView;
    }
}