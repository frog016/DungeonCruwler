using UnityEngine;

[RequireComponent(typeof(IHiddenObject))]
public class HiddenObjectDisplay : MonoBehaviour
{
    [SerializeField] private MeshRenderer _model;

    private IHiddenObject _hiddenObject;

    private void Awake()
    {
        _hiddenObject = GetComponent<IHiddenObject>();
        _hiddenObject.Discovered += Show;
    }

    private void OnDestroy()
    {
        _hiddenObject.Discovered -= Show;
    }

    private void Show()
    {
        _model.enabled = true;
    }
}