using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class DraggableUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float _alphaColor;
    [SerializeField] private Canvas _canvas;

    private Vector2 _previousPosition;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(Canvas canvas)
    {
        _canvas = canvas;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _previousPosition = _rectTransform.anchoredPosition;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = _alphaColor;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        var pointerObject = eventData.pointerCurrentRaycast.gameObject;
        if (pointerObject == null ||
            !pointerObject.TryGetComponent<UIElementCell>(out var cell) ||
            cell.Element != null)
            _rectTransform.anchoredPosition = _previousPosition;

        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }
}