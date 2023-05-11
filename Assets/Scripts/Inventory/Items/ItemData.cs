using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Description")]
    [SerializeField] private string _name;
    [SerializeField, TextArea] private string _description;

    public string Name => _name;
    public string Description => _description;
}