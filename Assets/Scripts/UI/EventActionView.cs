using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventActionView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action ActionCalled;

    public void Initialize<T>(T interactableEvent, IEventAction<T> action, ICharacter target) where T : IInteractableEvent
    {
        Debug.Log("Initialize Action Button");
        _text.text = action.ToString();
        //_button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() =>
        {
            action.Invoke(interactableEvent, target);
            ActionCalled?.Invoke();
        });
    }
}