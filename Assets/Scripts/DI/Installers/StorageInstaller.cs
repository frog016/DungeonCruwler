using UnityEngine;
using Zenject;

public class StorageInstaller : MonoInstaller
{
    [SerializeField] private StatDescriptionStorage _storage;

    public override void InstallBindings()
    {
        Container
            .BindInstance(_storage)
            .AsSingle();
    }
}