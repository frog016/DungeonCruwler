using System;
using System.Linq;
using UnityEngine;

public class ContextMenu : UIPanel
{
    [SerializeField] private ContextButton[] _buttons;

    public void Initialize(string[] names, Action[] actions)
    {
        var tuples = names
            .Zip(actions, Tuple.Create)
            .Zip(_buttons, (tuple, button) => Tuple.Create(tuple.Item1, tuple.Item2, button));

        foreach (var (actionName, action, button) in tuples)
        {
            button.gameObject.SetActive(true);
            button.Initialize(actionName, action);
        }
    }

    public override void Close()
    {
        base.Close();
        foreach (var button in _buttons)
            button.gameObject.SetActive(false);
    }
}