﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Weapon", fileName = "Weapon")]
public class Weapon : Equipment
{
    [SerializeField] private int _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private StatCount[] _requiredStats;
    [SerializeField] private WeaponAttackData[] _attacks;

    public DamageType DamageType => _damageType;
    public IEnumerable<Attack> Attacks => _attacks.Select(data => data.Attack);

    public int GetMaximumDamage(IStatsUser statsUser)
    {
        var statsDamage = _requiredStats.Sum(stat => statsUser.Stats.GetStat(stat.Stat) * stat.UsagePercentage);
        return _damage + Mathf.FloorToInt(statsDamage);
    }

    public WeaponAttackData GetAttackData<T>(T attack) where T : Attack
    {
        var attackData = _attacks.FirstOrDefault(data => data.Attack.GetType() == attack.GetType());
        if (attack == null)
            throw new ArgumentException($"Weapon ({name}) doesn't contains attack with type {typeof(T)}.");

        return attackData;
    }

    [Serializable]
    public class WeaponAttackData
    {
        [SerializeField] private int _damageThreshold;
        [SerializeField] private Attack _attack;

        public int DamageThreshold => _damageThreshold;
        public Attack Attack => _attack;
    }

    [Serializable]
    public class StatCount
    {
        [SerializeField] private StatType _stat;
        [SerializeField] private int _requiredCount;
        [SerializeField, Range(0f, 1f)] private float _usagePercentage;

        public StatType Stat => _stat;
        public int RequiredCount => _requiredCount;
        public float UsagePercentage => _usagePercentage;
    }
}