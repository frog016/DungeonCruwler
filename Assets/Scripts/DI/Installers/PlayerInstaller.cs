using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Character _character;

    public override void InstallBindings()
    {
        BindCharacter();
    }

    private void BindCharacter()
    {
        Container
            .Bind<ICharacter>()
            .FromInstance(_character)
            .AsSingle();
    }
}