using UnityEngine;
using Zenject;

public class EventPresenter : MonoBehaviour
{
    private EventBehaviour[] _eventBehaviours;
    private EventPanel _eventView;

    [Inject]
    public void Constructor(EventBehaviour[] eventBehaviours, EventPanel view)
    {
        _eventBehaviours = eventBehaviours;
        _eventView = view;
    }

    private void Start()
    {
        foreach (var holder in _eventBehaviours)
            holder.Interacted += PresentEventPanel;
    }

    private void OnDestroy()
    {
        foreach (var holder in _eventBehaviours)
            holder.Interacted -= PresentEventPanel;
    }

    private void PresentEventPanel(InteractionEventData data)
    {
        _eventView.Initialize(data.EventObject, data.InteractedWith);
        _eventView.Open();
    }
}