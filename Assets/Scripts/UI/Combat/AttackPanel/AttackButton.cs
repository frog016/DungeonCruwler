using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _attackNameText;

    public Attack Attack { get; private set; }
    public ICharacter Owner { get; private set; }
    public event Action<Attack> AttackChosen;

    public void Initialize(Attack attack, ICharacter owner)
    {
        Attack = attack;
        Owner = owner;
        _attackNameText.text = attack.name;
    }

    private void OnEnable() => _button.onClick.AddListener(Invoke);

    private void OnDisable() => _button.onClick.RemoveListener(Invoke);

    private void Invoke() => AttackChosen?.Invoke(Attack);
}