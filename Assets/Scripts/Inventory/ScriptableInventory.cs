using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory")]
public class ScriptableInventory : ScriptableObject, IInventory
{
    [SerializeField] private Weapon _weapon;

    public Weapon Weapon => _weapon;
}