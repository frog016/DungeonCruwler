using System.Collections.Generic;
using UnityEngine;

public class AttackListPresenter : MonoBehaviour
{
    [SerializeField] private CombatStateMachine _player;
    [SerializeField] private AttackPresenter _presenterPrefab;

    private List<AttackPresenter> _createdPresenters;

    private void Awake()
    {
        _createdPresenters = new List<AttackPresenter>();
        InitializePresenters();
    }

    private void OnEnable()
    {
        foreach (var presenter in _createdPresenters) 
            presenter.AttackChosen += OnAttackChosen;
    }

    private void OnDisable()
    {
        foreach (var presenter in _createdPresenters)
            presenter.AttackChosen -= OnAttackChosen;
    }

    private void InitializePresenters()
    {
        var weapon = _player.Inventory.Weapon;
        foreach (var attack in weapon.Attacks)
        {
            var presenter = Instantiate(_presenterPrefab, transform);
            presenter.Initialize(attack);
            _createdPresenters.Add(presenter);
        }
    }

    private void OnAttackChosen(Attack attack)
    {
        var attackGiver = (IPlayerAttackGiver)_player.AttackGiver;
        attackGiver.CurrentAttack = attack;
    }
}