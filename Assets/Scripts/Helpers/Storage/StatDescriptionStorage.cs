using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Storage/Stat Description", fileName = "StatDescriptionStorage")]
public class StatDescriptionStorage : Storage<StatType, StatDescriptionData>
{
    [SerializeField] private CompositeStatDescriptionData[] _otherElements;

    public override StatDescriptionData GetValue(StatType key)
    {
        return _elements.First(e => e.Stat == key);
    }

    public CompositeStatDescriptionData GetValue(CompositeStatType key)
    {
        return _otherElements.First(e => e.Stat == key);
    }

    public StatDescriptionData<TStat> GetValue<TStat>(TStat key) where TStat : Enum
    {
        if (key is StatType statKey)
            return _elements.First(e => e.Stat == statKey) as StatDescriptionData<TStat>;

        if (key is CompositeStatType compositeKey)
            return _otherElements.First(e => e.Stat == compositeKey) as StatDescriptionData<TStat>;

        throw new Exception($"{key} is not {typeof(StatType)} or {typeof(CompositeStatType)}.");
    }
}