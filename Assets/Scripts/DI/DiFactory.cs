using UnityEngine;
using Zenject;

public class DiFactory : IGameObjectFactory
{
    private readonly DiContainer _container;

    public DiFactory(DiContainer container)
    {
        _container = container;
    }

    public GameObject Create(GameObject prefab)
    {
        return _container.InstantiatePrefab(prefab);
    }

    public T CreateFromComponent<T>(T prefab) where T : Component
    {
        return _container.InstantiatePrefabForComponent<T>(prefab);
    }
}