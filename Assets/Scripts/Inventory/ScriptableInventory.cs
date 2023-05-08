using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory")]
public class ScriptableInventory : ScriptableObject, IInventory
{
    private readonly IInventory _inventory = new InfiniteInventory();

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