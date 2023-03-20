using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory")]
public class Inventory : ScriptableObject, IInventory
{
    [SerializeField] private Weapon _weapon;

    public Weapon Weapon => _weapon;
}