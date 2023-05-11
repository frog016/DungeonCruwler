using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory")]
public class ScriptableInventory : ScriptableObject, IInventory
{
    [SerializeField] private Equipment[] _equipments;
    [SerializeField] private ConsumableItem[] _items;

    private IInventory _inventory;

    private void OnEnable()
    {
        _inventory = new InfiniteInventory();
        var items = _equipments.Cast<IItem>().Concat(_items);
        foreach (var item in items)
            Add(item);
    }

    public void Add(IItem element)
    {
        _inventory.Add(element);
    }

    public void Remove(IItem element)
    {
        _inventory.Remove(element);
    }

    public IEnumerable<IItem> GetAll()
    {
        return _inventory.GetAll();
    }

    public IItem GetByHash(int itemHash)
    {
        return _inventory.GetByHash(itemHash);
    }
}