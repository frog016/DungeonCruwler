using System;
using UnityEngine;

[Serializable]
public class StatValuePair<TStat> where TStat : Enum
{
    [SerializeField] private int _value;
    [SerializeField] private TStat _stat;

    public int Value { get => _value; set => _value = value; }
    public TStat Stat { get => _stat; set => _stat = value; }

    public StatValuePair(int value, TStat stat)
    {
        Value = value;
        Stat = stat;
    }
}