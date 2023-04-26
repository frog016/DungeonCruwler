using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHiddenObject))]
public class MultipleObjectDisplay : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _renderers;

    private IHiddenObject _hiddenObject;

    private void Awake()
    {
        _hiddenObject = GetComponent<IHiddenObject>();
        _hiddenObject.Discovered += Show;
        foreach (var meshRenderer in _renderers)
        {
            meshRenderer.enabled = false;
        }
    }

    private void OnDestroy()
    {
        _hiddenObject.Discovered -= Show;
    }

    public void Add(MeshRenderer meshRenderer)
    {
        meshRenderer.enabled = false;
        _renderers.Add(meshRenderer);
    }

    public void Remove(MeshRenderer meshRenderer)
    {
        meshRenderer.enabled = true;
        _renderers.Remove(meshRenderer);
    }

    private void Show()
    {
        foreach (var meshRenderer in _renderers)
        {
            meshRenderer.enabled = true;
        }
    }
}