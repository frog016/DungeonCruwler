using System;
using UnityEngine;

[RequireComponent(typeof(IHiddenObject))]
public class HiddenObjectDisplay : MonoBehaviour
{
    [SerializeField] private MeshRenderer _model;

    private IHiddenObject _hiddenObject;

    private void Awake()
    {
        _hiddenObject = GetComponent<IHiddenObject>();
        _hiddenObject.Discovered += Display;
        _model.enabled = false;
    }

    private void OnDestroy()
    {
        _hiddenObject.Discovered -= Display;
    }

    private void Display()
    {
        _model.enabled = true;
    }
}