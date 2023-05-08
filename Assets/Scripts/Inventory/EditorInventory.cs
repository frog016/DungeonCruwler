using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class EditorInventory : MonoBehaviour, IInventory
{
    [SerializeField] private Equipment[] _equipments;
    [SerializeField] private ScriptableItem[] _items;

    private IInventory _inventory;

    private void Awake()
    {
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