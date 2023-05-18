using System;
using System.Collections.Generic;
using UnityEngine;

public class StatPresenter : MonoBehaviour
{
    [SerializeField] private StatView _statViewPrefab;
    [SerializeField] private CombatEntityBehaviour _character;

    private Dictionary<Enum, StatView> _views = new Dictionary<Enum, StatView>();

    private void Start()
    {
        _character.Stats.ValueChanged += ChangeText;
        CreateStatsView(_character.Stats);
        CreateStatsView(_character.CompositeStats);
    }

    private void OnDestroy()
    {
        _character.Stats.ValueChanged -= ChangeText;
    }

    private void CreateStatsView<TStat>(IStats<TStat> stats) where TStat : Enum
    {
        foreach (var (stat, value) in stats.AllStats)
        {
            var view = Instantiate(_statViewPrefab, transform);
            view.ChangeText(stat, value);
            _views[stat] = view;
        }
    }

    private void ChangeText<TStat>(TStat statType, int value) where TStat : Enum
    {
        _views[statType].ChangeText(statType, value);
    }
}
