using UnityEngine;
using Zenject;

public class TreasureUIPanel : UIPanel
{
    [SerializeField] private UIItemGrid _itemGrid;
    [SerializeField] private ItemUiContainer _itemUiContainerPrefab;
    
    private IGameObjectFactory _factory;
    private ICharacter _owner;
    private IInventory _treasure;

    [Inject]
    public void Constructor(IGameObjectFactory factory)
    {
        _factory = factory;
    }

    public void Initialize(IInventory treasure, ICharacter character)
    {
        _treasure = treasure;
        _owner = character;
        foreach (var item in treasure.GetAll())
        {
            var itemView = CreateItemUiContainer(item, character);
            _itemGrid.AddContent(itemView);
        }
    }

    public void GetAllItems()
    {
        foreach (var item in _treasure.GetAll())
            _owner.Inventory.Add(item);
    }

    private ItemUiContainer CreateItemUiContainer(IItem item, ICharacter character)
    {
        var itemContainer = _factory.CreateFromComponent(_itemUiContainerPrefab);
        itemContainer.Initialize(item as ScriptableItemContainer, character);
        return itemContainer;
    }
}