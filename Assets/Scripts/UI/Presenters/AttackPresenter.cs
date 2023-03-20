using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackPresenter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _attackNameText;

    public event Action<Attack> AttackChosen;

    private Attack _attack;

    public void Initialize(Attack attack)
    {
        _attack = attack;
        _attackNameText.text = attack.name;
    }

    private void OnEnable() => _button.onClick.AddListener(Invoke);

    private void OnDisable() => _button.onClick.RemoveListener(Invoke);

    private void Invoke() => AttackChosen?.Invoke(_attack);
}