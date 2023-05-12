using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContextButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _contextValue;
    [SerializeField] private Button _button;

    public void Initialize(string context, Action action)
    {
        _contextValue.text = context;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(action.Invoke);
    }
}