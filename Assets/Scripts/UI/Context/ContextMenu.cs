using System;
using System.Linq;
using UnityEngine;

public class ContextMenu : UIPanel
{
    [SerializeField] private ContextButton[] _buttons;

    public void Initialize(ContextAction[] actions)
    {
        var tuples = actions
            .Zip(_buttons, Tuple.Create);

        foreach (var (action, button) in tuples)
        {
            button.gameObject.SetActive(true);
            button.Initialize(action.Name, () => { action.Invoke(); Close(); });
        }
    }

    public override void Close()
    {
        base.Close();
        foreach (var button in _buttons)
            button.gameObject.SetActive(false);
    }
}