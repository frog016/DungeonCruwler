using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevel;
    [SerializeField] private FogOfWar _fog;
    [SerializeField] private Map _map;

    public override void InstallBindings()
    {
        BindMainLevel();
        BindBattleLevel();
        BindFog();
        BindMap();
    }

    private void BindMainLevel()
    {
        Container
            .BindInstance(_mainLevel)
            .AsSingle();
    }

    private void BindBattleLevel()
    {
        Container
            .BindInstance(_battleLevel)
            .AsSingle();
    }

    private void BindFog()
    {
        Container
            .BindInstance(_fog)
            .AsSingle();
    }

    private void BindMap()
    {
        Container
            .Bind<ITileableMap>()
            .FromInstance(_map)
            .AsSingle();
    }
}