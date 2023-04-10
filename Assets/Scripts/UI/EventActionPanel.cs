using System;
using System.Linq;
using UnityEngine;

public class EventActionPanel : MonoBehaviour
{
    [SerializeField] private EventActionView[] _actionViews;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void InitializeView<T>(T owner, IEventAction<T>[] actions, ICharacter character) where T : IInteractableEvent
    {
        Open();
        var viewActionPairs = _actionViews.Zip(actions, Tuple.Create);
        foreach (var (view, action) in viewActionPairs)
        {
            view.Initialize(owner, action, character);
            view.ActionCalled += Close;
        }
    }
}