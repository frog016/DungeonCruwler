using UnityEngine;
using Zenject;

public class EventInstaller : MonoInstaller
{
    [SerializeField] private EventBehaviour[] _traps;
    [SerializeField] private EventBehaviour[] _enemies;
    [SerializeField] private EventBehaviour[] _otherEvents;
    [SerializeField] private ScriptableEventAction[] _eventActions;

    public override void InstallBindings()
    {
        BindEvents(_traps);
        BindEvents(_enemies);
        BindEvents(_otherEvents);
        BindActions();
    }

    private void BindEvents(EventBehaviour[] events)
    {
        var type = typeof(EventBehaviour);
        foreach (var holder in events)
        {
            Container
                .Bind(type)
                .FromInstance(holder)
                .AsTransient();
        }
    }

    private void BindActions()
    {
        foreach (var scriptableEventAction in _eventActions)
        {
            Container
                .QueueForInject(scriptableEventAction);
        }
    }
}