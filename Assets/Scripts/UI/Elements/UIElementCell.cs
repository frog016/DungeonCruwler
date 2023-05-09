using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIElementCell : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public GameObject Element { get; private set; }

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Element != null || eventData.pointerDrag == null)
            return;

        Element = eventData.pointerDrag;
        if (!TryDrop(eventData))
            return;

        PlaceElementInCell(Element);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Element = null;
    }

    public void PlaceElementInCell(GameObject element)
    {
        Element = element;
        var otherRect = element.GetComponent<RectTransform>();
        otherRect.parent = _rectTransform;
        otherRect.anchoredPosition = Vector2.zero;
    }

    protected virtual bool TryDrop(PointerEventData eventData)
    {
        return true;
    }
}