using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackButtonsPanel : MonoBehaviour
{
    [SerializeField] private AttackButton _buttonPrefab;
    [SerializeField] private AttackTooltip _tooltip;
    [SerializeField] private Transform _root;

    private ICombatEntity _player;
    private AttackButton[] _buttons;

    private void Start()
    {
        _player = FindObjectsOfType<CombatEntityBehaviour>().First(entity => entity.Team == Team.Player);
        _buttons = InitializeButtons().ToArray();
        
        foreach (var presenter in _buttons) 
            presenter.AttackChosen += OnAttackChosen;
    }

    private void OnDestroy()
    {
        foreach (var presenter in _buttons)
            presenter.AttackChosen -= OnAttackChosen;
    }

    private IEnumerable<AttackButton> InitializeButtons()
    {
        var weapon = _player.GetWeapon();
        foreach (var attack in weapon.Attacks)
        {
            var attackButton = Instantiate(_buttonPrefab, _root);
            attackButton.Initialize(attack, _player);
            yield return attackButton;
        }
    }

    private void OnAttackChosen(Attack attack)
    {
        var attackGiver = (IPlayerAttackGiver)_player.AttackGiver;
        attackGiver.CurrentAttack = attack;
    }
}