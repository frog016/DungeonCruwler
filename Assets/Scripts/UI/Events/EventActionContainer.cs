using System;
using TMPro;
using UnityEngine;

public class EventActionContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultPercent;
    [SerializeField] private ContextButton _button;

    public event Action ActionCalled;

    public void Initialize(int chance, string actionName, Action action)
    {
        _resultPercent.text = $"({chance}%)";
        _button.Initialize(actionName, () => InvokeAction(action));
    }

    private void InvokeAction(Action action)
    {
        action.Invoke();
        ActionCalled?.Invoke();
    }
}