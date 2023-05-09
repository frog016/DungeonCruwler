using TMPro;
using UnityEngine;

public class EffectView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _chanceText;

    public void Initialize(string description, int chance)
    {
        _descriptionText.text = description;
        _chanceText.text = $"{chance}%";
    }
}