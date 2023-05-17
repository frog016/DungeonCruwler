using System;
using UnityEngine;

[Serializable]
public class StatDescriptionData : StatDescriptionData<StatType>
{
}

[Serializable]
public abstract class StatDescriptionData<TStat> : DescriptionData where TStat : Enum
{
    [SerializeField] private TStat _stat;

    public TStat Stat => _stat;
}