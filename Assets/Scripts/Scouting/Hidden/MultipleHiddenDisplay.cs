using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHiddenObject))]
public class MultipleHiddenDisplay : MonoBehaviour, ICollection<MeshRenderer>
{
    [SerializeField] private List<MeshRenderer> _meshRenderers;

    private IHiddenObject _hiddenObject;

    private void Awake()
    {
        Hide();
        _hiddenObject = GetComponent<IHiddenObject>();
    }

    private void OnEnable()
    {
        _hiddenObject.Discovered += Display;
    }

    private void OnDisable()
    {
        _hiddenObject.Discovered -= Display;
    }

    public void Add(MeshRenderer element)
    {
        _meshRenderers.Add(element);
    }

    public void Remove(MeshRenderer element)
    {
        _meshRenderers.Remove(element);
    }

    public IEnumerable<MeshRenderer> GetAll()
    {
        return _meshRenderers;
    }

    private void Display()
    {
        foreach (var meshRenderer in _meshRenderers)
            meshRenderer.enabled = true;
    }

    private void Hide()
    {
        foreach (var meshRenderer in _meshRenderers)
            meshRenderer.enabled = false;
    }
}