using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private ItemTooltip[] _itemTooltips;
    [SerializeField] private CommonTooltip _commonTooltip;
    [SerializeField] private ContextMenu _contextMenu;
    [SerializeField] private UIInventoryPanel _inventoryPanel;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private EventPanel _eventPanel;

    public override void InstallBindings()
    {
        BindItemTooltips();
        BindCommonTooltip();
        BindContextMenu();
        BindInventoryPanel();
        BindCanvas();
        BindPanel();
    }

    private void BindPanel()
    {
        Container
            .BindInstance(_eventPanel)
            .AsSingle();
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

    private void BindContextMenu()
    {
        Container
            .BindInstance(_contextMenu)
            .AsSingle();
    }

    private void BindInventoryPanel()
    {
        Container
            .BindInstance(_inventoryPanel)
            .AsSingle();
    }

    private void BindCanvas()
    {
        Container
            .BindInstance(_canvas)
            .AsSingle()
            .WithConcreteId("Ui");
    }
}