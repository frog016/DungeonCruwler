using UnityEngine;
using Zenject;

public class EntityInstaller : MonoInstaller
{
    [SerializeField] private MovementHandler[] _handlers;

    public override void InstallBindings()
    {
        BindPathfinder();
        BindMovementHandlers();
    }

    private void BindPathfinder()
    {
        Container
            .Bind<IPathfinder>()
            .To<TileablePathfinder>()
            .AsSingle();
    }

    private void BindMovementHandlers()
    {
        foreach (var handler in _handlers)
        {
            Container
                .Bind<ITurnEntity>()
                .FromInstance(handler)
                .AsTransient();
        }
    }
}