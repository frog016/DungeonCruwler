using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item", fileName = "ScriptableItem")]
public class ConsumableItem : ScriptableItemContainer
{
    public override int StackSize { get;}

    public override void Activate(IStatsUser statsUser)
    {
    }
}