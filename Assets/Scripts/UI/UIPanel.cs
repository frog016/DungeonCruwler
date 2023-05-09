using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] private bool _closeOnAwake;

    private void Awake()
    {
        if (_closeOnAwake)
            Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}