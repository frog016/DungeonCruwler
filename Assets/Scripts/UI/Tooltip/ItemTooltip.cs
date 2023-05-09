using TMPro;
using UnityEngine;

public abstract class ItemTooltip<TItem> : UIPanel where TItem : IItem
{
    [SerializeField] private TextMeshProUGUI _titleText;

    public virtual void Initialize(string itemName, TItem item, ICharacter itemOwner)
    {
        _titleText.text = itemName;
    }
}