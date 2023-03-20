using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Configuration/CompositeConfig", fileName = "CompositeStatConfig")]
public class CompositeStatConfig : ScriptableObject
{
    [SerializeField] private Config[] _configs;

    public IEnumerable<Config> Configs => _configs;

    [Serializable]
    public class Config
    {
        [SerializeField] private CompositeStatType _compositeStat;
        [SerializeField] private StatData[] _influencingStats;

        public CompositeStatType CompositeStat => _compositeStat;
        public IEnumerable<(StatType, float)> InfluencingStats => _influencingStats.Select(value => (value.Stat, value.AmountPart));

        [Serializable]
        private class StatData
        {
            [SerializeField] private StatType _stat;
            [SerializeField, Range(0f, 1f)] private float _amountPart;

            public StatType Stat => _stat;
            public float AmountPart => _amountPart;
        }
    }
}