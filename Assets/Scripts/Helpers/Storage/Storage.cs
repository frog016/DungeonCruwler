using UnityEngine;

public abstract class Storage<TKey, TElement> : ScriptableObject
{
    [SerializeField] protected TElement[] _elements;

    public abstract TElement GetValue(TKey key);
}