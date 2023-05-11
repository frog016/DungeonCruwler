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
        if (_blackout == null)
            return;

        _blackout.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        if (_blackout == null)
            return;

        _blackout.SetActive(false);
    }
}