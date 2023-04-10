using System.Linq;
using UnityEngine;

public class TrapEventPresenter : MonoBehaviour
{
    [SerializeField] private TrapEvent _event;
    [SerializeField] private EventActionPanel _actionPanel;

    private void OnEnable()
    {
        _event.Interacted += ShowEventActions;
        _actionPanel.Close();
    }

    private void OnDisable()
    {
        _event.Interacted -= ShowEventActions;
    }

    private void ShowEventActions(ICharacter character)
    {
        var actions = _event.Actions.ToArray();
        _actionPanel.InitializeView(_event, actions, character);
    }
}