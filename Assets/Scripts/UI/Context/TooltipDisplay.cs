using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Canvas _canvas;

    protected virtual void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
    }

    protected void SetTooltipPosition(PointerEventData eventData, RectTransform tooltip)
    {
        var position = eventData.position / _canvas.scaleFactor;
        tooltip.anchorMin = position;
    }
}