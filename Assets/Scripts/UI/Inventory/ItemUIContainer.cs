using TMPro;
using UnityEngine;

public class ItemUiContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemNameText;

    public ScriptableItemContainer Item { get; private set; }
    public ICharacter Owner { get; private set; }

    public void Initialize(ScriptableItemContainer item, ICharacter owner)
    {
        Item = item;
        Owner = owner;

        _itemNameText.text = item.Data.Name;
    }
}