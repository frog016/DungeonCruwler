using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[Serializable]
public class EditorInventory : MonoBehaviour, IInventory
{
    [SerializeField] private Equipment[] _equipments;
    [SerializeField] private ConsumableItem[] _items;

    private IInventory _inventory;

    [Inject]
    public void Constructor()
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