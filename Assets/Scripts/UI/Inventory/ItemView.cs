using TMPro;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemNameText;

    public IItem Item { get; private set; }

    public void Initialize(string itemName, IItem item)
    {
        _itemNameText.text = itemName;
        Item = item;
    }
}