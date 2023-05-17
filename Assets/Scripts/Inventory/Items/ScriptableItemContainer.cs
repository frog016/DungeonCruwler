using UnityEngine;

public abstract class ScriptableItemContainer : ScriptableObject, IItem
{
    [SerializeField] private DescriptionData _data;

    public DescriptionData Data => _data;
    public abstract int StackSize { get; }
    public abstract void Activate(IStatsUser statsUser);
}