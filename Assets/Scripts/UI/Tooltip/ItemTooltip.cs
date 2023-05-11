using TMPro;
using UnityEngine;

public abstract class ItemTooltip : UIPanel
{
    [SerializeField] private TextMeshProUGUI _itemNameText;

    public virtual void Initialize(ScriptableItemContainer item, ICharacter owner)
    {
        _itemNameText.text = item.Data.Name;
    }
}