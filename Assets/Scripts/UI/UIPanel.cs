using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] private bool _closeOnAwake;
    [SerializeField] private GameObject _blackout;

    private void Awake()
    {
        if (_closeOnAwake)
            Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        _blackout.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        _blackout.SetActive(false);
    }
}