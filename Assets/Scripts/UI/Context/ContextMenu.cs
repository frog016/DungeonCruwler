using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ContextMenu<T> : UIPanel, IPointerDownHandler
{
    [SerializeField] protected T _contextOwner;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button[] _actionButtons;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var position = eventData.position / _canvas.scaleFactor;
        SetPosition(position);
        SubscribeActions(_actionButtons);
    }

    protected abstract void SubscribeActions(Button[] buttons);

    private void SetPosition(Vector2 position)
    {
        _rectTransform.anchorMin = position;
    }
}