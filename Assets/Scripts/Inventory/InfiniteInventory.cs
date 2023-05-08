using System.Collections.Generic;
using System.Linq;

public class InfiniteInventory : IInventory
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
        return _storage.SelectMany(itemCountPair => itemCountPair.Value);
    }

    public IItem GetByHash(int itemHash)
    {
        if (!_storage.TryGetValue(itemHash, out var itemList))
            throw new KeyNotFoundException();

        return itemList.First();
    }

    private bool TryChangeStackCount(IItem element, int amount)
    {
        var count = _storage[element.GetHashCode()].Count + amount;

        if (count <= 0)
        {
            _storage.Remove(element.GetHashCode());
            return true;
        }

        if (count <= element.StackSize)
            return false;

        _storage[element.GetHashCode()].Add(element);
        return true;

    }
}