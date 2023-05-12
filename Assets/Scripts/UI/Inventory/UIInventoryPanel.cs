using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class UIInventoryPanel : UIPanel
{
    [SerializeField] private UIItemGrid _itemGrid;
    [SerializeField] private UIEquipmentGrid _equipmentGrid;
    [SerializeField] private ItemUiContainer _itemUiContainerPrefab;
    [SerializeField] private GameObject _blackout;

    public ICharacter Owner { get; private set; }
    public UIEquipmentGrid EquipmentGrid => _equipmentGrid;
    public UIItemGrid ItemGrid => _itemGrid;

    private IGameObjectFactory _factory;

    [Inject]
    public void Constructor(ICharacter character, IGameObjectFactory factory)
    {
        Owner = character;
        _factory = factory;
    }

    private void Start()
    {
        InitializeItemGrid(Owner.Inventory);
        InitializeEquipmentGrid(Owner.EquipmentWearer);
    }

    public override void Open()
    {
        base.Open();
        _blackout.SetActive(true);
    }

    public override void Close()
    {
        base.Close();
        _blackout.SetActive(false);
    }

    private void InitializeItemGrid(IInventory inventory)
    {
        foreach (var item in inventory.GetAll())
        {
            var itemView = CreateItemUiContainer(item);
            _itemGrid.AddContent(itemView);
        }
    }

    private void InitializeEquipmentGrid(IEquipmentWearer equipmentWearer)
    {
        foreach (var equipment in equipmentWearer.GetAll())
        {
            var itemView = CreateItemUiContainer(equipment);
            if (TryInitializeTwoHanded(itemView, equipment))
                continue;

            _equipmentGrid.AddContent(itemView);
        }
    }

    private bool TryInitializeTwoHanded(ItemUiContainer itemUiContainer, IEquipmentItem equipment)
    {
        if (equipment.Slot != EquipmentSlot.TwoHand) 
            return false;

        var itemViewCopy = CreateItemUiContainer(equipment);
        var viewCellPairs = new ItemUiContainer[] { itemUiContainer, itemViewCopy }
            .Zip(_equipmentGrid.GetEmptyCells(itemUiContainer), Tuple.Create);

        foreach (var (view, cell) in viewCellPairs)
            _equipmentGrid.AddContentTo(view, cell);

        return true;

    }

    private ItemUiContainer CreateItemUiContainer(IItem item)
    {
        var itemContainer = _factory.CreateFromComponent(_itemUiContainerPrefab);
        itemContainer.Initialize(item as ScriptableItemContainer, Owner);
        return itemContainer;
    }
}