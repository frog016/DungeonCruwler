using System;
using UnityEngine;

[Serializable]
public class Range
{
    [SerializeField] private int _from;
    [SerializeField] private int _to;

    public int From => _from;
    public int To => _to;

    public Range(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public bool InRange(int value)
    {
        return value >= From && value <= To;
    }
}