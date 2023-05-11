using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item", fileName = "ScriptableItem")]
public class ScriptableItem : ScriptableObject, IItem
{
    [SerializeField] private string _name;

    public int StackSize { get; set; }

    public virtual void Activate(IStatsUser statsUser)
    {
    }
}