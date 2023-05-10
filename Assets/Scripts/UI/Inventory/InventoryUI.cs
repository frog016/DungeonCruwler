using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : UIPanel
{
    [SerializeField] private ItemCellGrid _itemGrid;
    [SerializeField] private EquipmentCellGrid _equipmentGrid;
    [SerializeField] private ItemView _itemViewPrefab;
    [SerializeField] private StatsPanel _statsPanel;

    public IInventory Inventory;
    public IEquipmentWearer Wearer;

    public void Constructor(ICharacter character)
    {
        Inventory = character.Inventory;
        Wearer = character.EquipmentWearer;

        InitializeGrid(() => Inventory
            .GetAll()
            .Zip(_itemGrid.Cells, ValueTuple.Create));
        InitializeGrid(() => Wearer
            .GetAll()
            .Select(equipment => (equipment as IItem, _equipmentGrid.Cells.First(cell => equipment.Slot == cell.Slot))));

        _statsPanel.Constructor(character);
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