using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Modifier/ScriptableModifier", fileName = "RaceName")]
public class ScriptableStatModifier : ScriptableObject, IStatsModifier
{
    [SerializeField] private StatInfo[] _modificationStats;

    public void Modify(IStats stats)
    {
        foreach (var statInfo in _modificationStats)
            stats.ChangeStatByValue(statInfo.Stat, statInfo.Value);
    }

    [Serializable]
    public struct StatInfo
    {
        [SerializeField] private Stat _stat;
        [SerializeField] private float _value;

        public Stat Stat => _stat;
        public float Value => _value;
    }
}