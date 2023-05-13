using UnityEngine;
using Zenject;

public class EventInstaller : MonoInstaller
{
    [SerializeField] private EventBehaviour[] _traps;

    public override void InstallBindings()
    {
        BindHolders();
    }


    private void BindHolders()
    {
        var type = typeof(EventBehaviour);
        foreach (var holder in _traps)
        {
            Container
                .Bind(type)
                .FromInstance(holder)
                .AsTransient();
        }
    }
}