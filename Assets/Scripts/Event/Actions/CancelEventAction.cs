using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Event/Actions/Cancel Event", fileName = "CancelEventAction")]
public class CancelEventAction : ScriptableEventAction
{
    private EventPanel _eventPanel;

    [Inject]
    public void Constructor(EventPanel eventPanel)  // TODO : Inject this
    {
        _eventPanel = eventPanel;
    }

    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);
        MoveCharacterBack(target);  // TODO : Add this to another actions
        _eventPanel.Close();
    }
}