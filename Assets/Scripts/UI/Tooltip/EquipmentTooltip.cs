using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentTooltip : ItemTooltip
{
    [SerializeField] private StatView[] _statViews;

    public override void Close()
    {
        base.Close();
        _statViews.Apply(view => view.gameObject.SetActive(false));
    }

    public override void Initialize(ScriptableItemContainer item, ICharacter owner)
    {
        base.Initialize(item, owner);
        var statViewPairs = GetAllStats(item as Equipment)
            .Zip(_statViews, Tuple.Create);
        foreach (var (statValuePair, view) in statViewPairs)
            ShowStatView(view, statValuePair);
    }

    private static void ShowStatView<TStat>(StatView view, StatValuePair<TStat> statValuePair) where TStat : Enum
    {
        view.gameObject.SetActive(true);
        view.ChangeText(statValuePair.Stat, statValuePair.Value);
    }

    private static IEnumerable<StatValuePair<Enum>> GetAllStats(Equipment item)
    {
        return item
            .AdditionalStats
            .Select(stat => new StatValuePair<Enum>(stat.Item2, stat.Item1))
            .Concat(item.AdditionalCompositeStats
                .Select(stat => new StatValuePair<Enum>(stat.Item2, stat.Item1)));
    }
}