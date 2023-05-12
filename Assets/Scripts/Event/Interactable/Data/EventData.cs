using System;
using UnityEngine;

[Serializable]
public class EventData
{
    [SerializeField] private int _complexityClass;

    public int ComplexityClass => _complexityClass;
}