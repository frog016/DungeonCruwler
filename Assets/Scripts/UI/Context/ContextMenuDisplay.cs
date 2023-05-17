using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class ContextMenuDisplay : MonoBehaviour, IPointerDownHandler
{
    private Canvas _canvas;
    private ContextMenu _contextMenu;

    [Inject]
    public void Constructor(Canvas canvas, ContextMenu contextMenu)
    {
        _canvas = canvas;
        _contextMenu = contextMenu;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InitializeMenu(eventData, _contextMenu);
    }

    protected abstract void InitializeMenu(PointerEventData eventData, ContextMenu menu);
}