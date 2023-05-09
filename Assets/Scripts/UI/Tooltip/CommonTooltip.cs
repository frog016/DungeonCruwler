using TMPro;
using UnityEngine;

public class CommonTooltip : UIPanel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    public void Initialize(string title, string description)
    {
        _titleText.text = title;
        _descriptionText.text = description;
    }
}