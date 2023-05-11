using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipDisplay<T> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler where T : UIPanel
{
    private T _tooltip;
    private Canvas _canvas;

    public void Constructor(T tooltip)
    {
        _tooltip = tooltip;
    }

    protected virtual void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         InitializeTooltip(_tooltip);
        _tooltip.Open();

        var position = eventData.position / _canvas.scaleFactor;
        _tooltip.GetComponent<RectTransform>().anchorMin = position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tooltip.Close();
    }

    protected abstract void InitializeTooltip(T tooltip);
}