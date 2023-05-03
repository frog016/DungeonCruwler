using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory")]
public class ScriptableInventory : ScriptableObject, IInventory
{
    private readonly Dictionary<int, List<IItem>> _storage = new Dictionary<int, List<IItem>>();
    
    public void Add(IItem element)
    {
        if (_storage.TryAdd(element.GetHashCode(), new List<IItem> { element }) ||
            TryChangeStackCount(element, 1))
            return;
        
        _storage[element.GetHashCode()].Add(element);
    }

    public void Remove(IItem element)
    {
        var key = element.GetHashCode();
        if (!_storage.TryGetValue(key, out var list) || 
            TryChangeStackCount(element, -1)) 
            return;

        list.Remove(element);
        if (list.Count == 0)
            _storage.Remove(key);
    }

    public IEnumerable<IItem> GetAll()
    {
        return _storage.Select(itemCountPair =>)
    }

    public IItem GetByHash(int itemHash)
    {
        throw new System.NotImplementedException();
    }

    private bool TryChangeStackCount(IItem element, int amount)
    {
        if (element is not IConsumableItem item) 
            return false;

        item.Count += amount;
        if (item.Count <= 0)
            _storage.Remove(item.GetHashCode());
        
        return true;

    }
}