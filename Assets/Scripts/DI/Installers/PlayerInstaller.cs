using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Character _character;
    [SerializeField] private Camera _camera;

    public override void InstallBindings()
    {
        BindCharacter();
        BindCamera();
    }

    private void BindCharacter()
    {
        Container
            .Bind<ICharacter>()
            .FromInstance(_character)
            .AsSingle();
    }

    private void BindCamera()
    {
        Container
            .BindInstance(_camera)
            .AsSingle();
    }
}