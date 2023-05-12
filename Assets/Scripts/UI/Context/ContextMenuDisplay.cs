using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class ContextMenuDisplay : MonoBehaviour, IPointerDownHandler
{
    private Canvas _canvas;
    private ContextMenu _contextMenu;
    private RectTransform _rectTransform;

    [Inject]
    public void Constructor([InjectLocal(Id = "Ui")]Canvas canvas, ContextMenu contextMenu)
    {
        _canvas = canvas;
        _contextMenu = contextMenu;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var position = eventData.position / _canvas.scaleFactor;
        SetPosition(position);
        InitializeMenu(eventData.pointerCurrentRaycast.gameObject, _contextMenu);
    }

    protected abstract void InitializeMenu(GameObject clickedObject, ContextMenu menu);

    private void SetPosition(Vector2 position)
    {
        _rectTransform.anchorMin = position;
    }
}