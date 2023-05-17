using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private DamageableUnit _damageableUnit;

    private void Start()
    {
        _damageableUnit.HealthChanged += OnHealthChanged;
        _damageableUnit.HealthChanged += OnDied;
        OnHealthChanged(_damageableUnit.Health);
    }

    private void OnDestroy()
    {
        _damageableUnit.HealthChanged -= OnHealthChanged;
        _damageableUnit.HealthChanged -= OnDied;
    }

    private void OnHealthChanged(int health)
    {
        _fillImage.fillAmount = (float)health / _damageableUnit.MaxHealth;
        _healthText.text = $"{health}/{_damageableUnit.MaxHealth}";
    }

    private void OnDied(int health)
    {
        if (health == 0)
            enabled = false;
    }
}