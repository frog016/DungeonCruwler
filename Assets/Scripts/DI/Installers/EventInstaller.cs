using UnityEngine;
using Zenject;

public class EventInstaller : MonoInstaller
{
    [SerializeField] private InteractableEventHolder[] _eventHolders;

    public override void InstallBindings()
    {
        BindHolders();
    }


    private void BindHolders()
    {
        var type = typeof(InteractableEventHolder);
        foreach (var holder in _eventHolders)
        {
            Container
                .Bind(type)
                .FromInstance(holder)
                .AsTransient();
        }
    }
}