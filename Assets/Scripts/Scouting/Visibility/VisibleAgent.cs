using UnityEngine;

public class VisibleAgent : MonoBehaviour, IVisible
{
    private Renderer[] _renderers;

    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>();
        Hide();
    }

    public void Show()
    {
        _renderers.Apply(view => view.enabled = true);
    }

    public void Hide()
    {
        _renderers.Apply(view => view.enabled = false);
    }
}