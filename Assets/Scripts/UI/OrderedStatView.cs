using System;
using TMPro;
using UnityEngine;

public abstract class OrderedStatView<TStat> : MonoBehaviour where TStat : Enum
{
    [SerializeField] private TStat _stat;
    [SerializeField] private TextMeshProUGUI _value;

    public TStat Stat => _stat;

    public void ChangeText(int value)
    {
        _value.text = $"{value}";
    }
}

public class OrderedStatView : OrderedStatView<StatType>
{
}