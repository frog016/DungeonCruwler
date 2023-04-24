using System;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    public event Action<ITargetable> TurnEnded;
    public ITargetable Current => _entities[_currentIndex];

    private int _currentIndex;
    private List<ITargetable> _entities;

    public void Constructor(List<ITargetable> entities)
    {
        _entities = entities;
    }

    public void Next()
    {
        _currentIndex = (_currentIndex+ 1) % _entities.Count;
    }

    public void EndTurn()
    {
        TurnEnded?.Invoke(null);
        Next();
    }
}