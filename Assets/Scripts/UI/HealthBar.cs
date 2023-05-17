using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private DamageableUnit _damageableUnit;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _damageableUnit.HealthChanged += OnHealthChanged;
        _damageableUnit.HealthChanged += OnDied;
    }

    private void Update()
    {
        if (_damageableUnit == null)
            return;

        _healthText.text = $"{_damageableUnit.Health}/{_damageableUnit.MaxHealth}";
        FollowAt();
    }

    private void OnDestroy()
    {
        _damageableUnit.HealthChanged -= OnHealthChanged;
        _damageableUnit.HealthChanged -= OnDied;
    }

    private void FollowAt()
    {
        var screenPosition = _camera.WorldToScreenPoint(_damageableUnit.transform.position) + _offset;
        _fillImage.transform.position = screenPosition;
    }

    private void OnHealthChanged(int health)
    {
        _fillImage.fillAmount = (float)health / _damageableUnit.MaxHealth;
    }

    private void OnDied(int health)
    {
        if (health == 0)
            Destroy(gameObject);
    }
}
