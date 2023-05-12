using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Event/Actions/Cancel Event", fileName = "CancelEventAction")]
public class CancelEventAction : ScriptableEventAction
{
    private EventPanel _eventPanel;

    [Inject]
    public void Constructor(EventPanel eventPanel)
    {
        _eventPanel = eventPanel;
    }

    public override void Invoke(InteractableEventHolder owner, ICharacter target)
    {
        base.Invoke(owner, target);
        MoveCharacterBack(target);
        _eventPanel.Close();
    }
}