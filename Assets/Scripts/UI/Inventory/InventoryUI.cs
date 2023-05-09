using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : UIPanel
{
    [SerializeField] private ItemCellGrid _itemGrid;
    [SerializeField] private EquipmentCellGrid _equipmentGrid;
    [SerializeField] private ItemView _itemViewPrefab;

    public IInventory Inventory;
    public IEquipmentWearer Wearer;

    public void Constructor(IItemUser itemUser)
    {
        Inventory = itemUser.Inventory;
        Wearer = itemUser.EquipmentWearer;

        InitializeGrid(() => Inventory
            .GetAll()
            .Zip(_itemGrid.Cells, ValueTuple.Create));
        InitializeGrid(() => Wearer
            .GetAll()
            .Select(equipment => (equipment as IItem, _equipmentGrid.Cells.First(cell => equipment.Slot == cell.Slot))));
    }

    private void InitializeGrid<TCell>(Func<IEnumerable<(IItem, TCell)>> mapper) where TCell : UIElementCell
    {
        foreach (var (item, cell) in mapper())
        {
            var itemView = Instantiate(_itemViewPrefab);
            itemView.Initialize(item.ToString(), item);
            cell.PlaceElementInCell(itemView.gameObject);
        }
    }
}