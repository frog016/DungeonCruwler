using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Round : MonoBehaviour
{
    public event Action<ITurnEntity> TurnStarted;
    public event Action<ITurnEntity> TurnEnded;
    public ITurnEntity Current => _entities[_currentIndex];

    private int _currentIndex;
    private List<ITurnEntity> _entities;

    public void Constructor(IEnumerable<ITurnEntity> entities)
    {
        _entities = entities.ToList();
    }

    private void Start()
    {
        TurnStarted?.Invoke(Current);
    }

    public void Next()
    {
        TurnEnded?.Invoke(Current);
        _currentIndex = (_currentIndex+ 1) % _entities.Count;
        TurnStarted?.Invoke(Current);
    }
}