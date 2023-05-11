using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private ItemTooltip[] _itemTooltips;
    [SerializeField] private CommonTooltip _commonTooltip;
    [SerializeField] private UIInventoryPanel _inventoryPanel;

    public override void InstallBindings()
    {
        BindItemTooltips();
        BindCommonTooltip();
        BindInventoryPanel();
    }

    private void BindItemTooltips()
    {
        var type = typeof(ItemTooltip);
        foreach (var tooltip in _itemTooltips)
        {
            Container
                .Bind(type)
                .FromInstance(tooltip)
                .AsTransient();
        }
    }

    private void BindCommonTooltip()
    {
        Container
            .BindInstance(_commonTooltip)
            .AsSingle();
    }

    private void BindInventoryPanel()
    {
        Container
            .BindInstance(_inventoryPanel)
            .AsSingle();
    }
}