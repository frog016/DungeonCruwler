using UnityEngine;
using Zenject;

public class EventPresenter : MonoBehaviour
{
    private InteractableEventHolder[] _holders;
    private EventPanel _eventView;

    [Inject]
    public void Constructor(InteractableEventHolder[] holders, EventPanel view)
    {
        _holders = holders;
        _eventView = view;
    }

    private void Start()
    {
        foreach (var holder in _holders)
            holder.Interacted += PresentEventPanel;
    }

    private void OnDestroy()
    {
        foreach (var holder in _holders)
            holder.Interacted -= PresentEventPanel;
    }

    private void PresentEventPanel(InteractionEventData data)
    {
        _eventView.Initialize(data.Event as ScriptableEvent, data.InteractedWith, data.EventObject);
        _eventView.Open();
    }
}