using TMPro;
using UnityEngine;

public class CommonItemTooltip : ItemTooltip
{
    [SerializeField] private TextMeshProUGUI _description;

    public override void Initialize(ScriptableItemContainer item, ICharacter owner)
    {
        base.Initialize(item, owner);
        _description.text = item.Data.Description;
    }
}