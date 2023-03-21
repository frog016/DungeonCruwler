using UnityEngine;

public abstract class Level<TData> : MonoBehaviour
{
    [SerializeField] protected Camera _activeCamera;

    public abstract void Load(TData data);
    public abstract void Unload();
}