using UnityEngine;

public abstract class ScriptableItemContainer : ScriptableObject, IItem
{
    [SerializeField] private ItemData _data;

    public ItemData Data => _data;
    public abstract int StackSize { get; }
    public abstract void Activate(IStatsUser statsUser);
}