using UnityEngine;

public abstract class ConsumableItem : ScriptableObject, IConsumableItem
{
    public int Count { get; set; }

    public abstract void Activate(IStatsUser statsUser);
}