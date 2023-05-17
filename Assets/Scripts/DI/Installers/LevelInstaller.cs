using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevel;

    public override void InstallBindings()
    {
        BindMainLevel();
        BindBattleLevel();
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
}