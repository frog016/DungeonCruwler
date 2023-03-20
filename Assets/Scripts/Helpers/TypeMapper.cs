using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TypeMapper<TKey, TValue> : ScriptableObject
{
    [SerializeField] private TypePair[] _pairs;

    private Dictionary<TKey, TValue> _map;

    private void OnEnable()
    {
        _map = _pairs
            .ToDictionary(key => key.KeyType, value => value.ValueType);
    }

    public TValue GetValue(TKey key)
    {
        if (!_map.TryGetValue(key, out var value))
            throw new KeyNotFoundException($"{nameof(TypeMapper<TKey, TValue>)}({GetType()}) doesn't contains key {key}.");
        
        return value;
    }

    [Serializable]
    public class TypePair
    {
        [SerializeField] private TKey _keyType;
        [SerializeField] private TValue _valueType;

        public TKey KeyType => _keyType;
        public TValue ValueType => _valueType;
    }
}