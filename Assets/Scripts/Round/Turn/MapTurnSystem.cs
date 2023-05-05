using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapTurnSystem : MonoBehaviour, ITurnSystem
{
    public ITurnEntity Current => _entities[_currentIndex];
    public event Action RoundEnded;

    private int _currentIndex;
    private List<ITurnEntity> _entities;
    public bool _isInitialized;

    public void Constructor(IEnumerable<ITurnEntity> entities)
    {
        _entities = entities.ToList();
        _isInitialized = true;
    }

    public void Next()
    {
        Current.OnTurnEnded();
        _currentIndex = (_currentIndex + 1) % _entities.Count;
        if (_currentIndex == 0)
            RoundEnded?.Invoke();

        Current.OnTurnStarted();
    }
}