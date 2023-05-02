using System.Linq;
using UnityEngine;

public class TrapEventPresenter : MonoBehaviour
{
    [SerializeField] private EventActionPanel _actionPanel;

    private void OnEnable()
    {
        _actionPanel.Close();
        TrapEvent.EventInteracted += ShowEventActions;
    }

    private void OnDisable()
    {
        TrapEvent.EventInteracted -= ShowEventActions;
    }

    private void ShowEventActions(TrapEvent trapEvent, ICharacter character)
    {
        var actions = trapEvent.Actions.ToArray();
        _actionPanel.InitializeView(trapEvent, actions, character);
    }
}