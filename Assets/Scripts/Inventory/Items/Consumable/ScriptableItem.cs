using UnityEngine;

public abstract class ScriptableItem : ScriptableObject, IItem
{
    public int StackSize { get; set; }
    public abstract void Activate(IStatsUser statsUser);
}