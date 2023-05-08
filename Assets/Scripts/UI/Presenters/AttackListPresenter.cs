using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackListPresenter : MonoBehaviour
{
    [SerializeField] private AttackPresenter _presenterPrefab;

    private ICombatEntity _player;
    private List<AttackPresenter> _createdPresenters;

    private void Start()
    {
        _player = FindObjectsOfType<CombatEntity>().First(entity => entity.Team == Team.Player);
        _createdPresenters = InitializePresenters()
            .ToList();
        
        foreach (var presenter in _createdPresenters) 
            presenter.AttackChosen += OnAttackChosen;
    }

    private void OnDestroy()
    {
        foreach (var presenter in _createdPresenters)
            presenter.AttackChosen -= OnAttackChosen;
    }

    private IEnumerable<AttackPresenter> InitializePresenters()
    {
        var weapon = _player.GetWeapon();
        foreach (var attack in weapon.Attacks)
        {
            var presenter = Instantiate(_presenterPrefab, transform);
            presenter.Initialize(attack);
            yield return presenter;
        }
    }

    private void OnAttackChosen(Attack attack)
    {
        var attackGiver = (IPlayerAttackGiver)_player.AttackGiver;
        attackGiver.CurrentAttack = attack;
    }
}