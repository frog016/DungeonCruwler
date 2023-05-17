using TMPro;
using UnityEngine;

public  class AttackTooltip : UIPanel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private EffectView _effectView;

    public void Initialize(string title, int damage, string effectDescription, int effectChance)
    {
        _titleText.text = title;
        _effectView.Initialize(effectDescription, effectChance);
        if (_damageText != null)
            _damageText.text = damage.ToString();
    }
}