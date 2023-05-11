using System;
using System.Linq;
using UnityEngine.EventSystems;
using Zenject;

public class StatTooltipDisplay : TooltipDisplay
{
    private CommonTooltip _tooltip;
    private StatDescriptionStorage _storage;

    [Inject]
    public void Constructor(CommonTooltip tooltip, StatDescriptionStorage storage)
    {
        _tooltip = tooltip;
        _storage = storage;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (TryInitializeStatView<StatType>(eventData) || TryInitializeStatView<CompositeStatType>(eventData))
            return;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _tooltip?.Close();
    }

    private bool TryInitializeStatView<TStat>(PointerEventData eventData) where TStat : Enum
    {
        if (!TryGetStatView<TStat>(eventData, out var view)) 
            return false;

        var data = _storage.GetValue(view.Stat);
        _tooltip.Initialize(data.Name, data.Description);

        return true;

    }

    private bool TryGetStatView<TStat>(PointerEventData eventData, out OrderedStatView<TStat> view) where TStat : Enum
    {
        OrderedStatView<TStat> statView = null;
        _ = eventData.hovered.FirstOrDefault(obj => obj.TryGetComponent<OrderedStatView<TStat>>(out statView));
        view = statView;

        return view != null;
    }
}