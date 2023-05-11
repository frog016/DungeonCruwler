using Zenject;

public class FactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IGameObjectFactory>()
            .To<DiFactory>()
            .AsSingle();
    }
}