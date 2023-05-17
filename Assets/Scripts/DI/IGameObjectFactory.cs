using UnityEngine;

public interface IGameObjectFactory
{
    GameObject Create(GameObject prefab);
    T CreateFromComponent<T>(T prefab) where T : Component;
}