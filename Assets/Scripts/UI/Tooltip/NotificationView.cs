using TMPro;
using UnityEngine;

public class NotificationView : UIPanel
{
    [SerializeField] private TextMeshProUGUI _titleText;

    public void Initialize(string title, string description)
    {
        _titleText.text = title;
    }
}