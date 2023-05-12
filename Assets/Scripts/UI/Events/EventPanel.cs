using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class EventPanel : UIPanel
{
    [SerializeField] private TextMeshProUGUI _eventNameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private EventActionContainer[] _actionContainers;

    public void Initialize(ScriptableEvent owner, ICharacter character, InteractableEventHolder holder)
    {
        _eventNameText.text = owner.DescriptionData.Name;
        _descriptionText.text = owner.DescriptionData.Description;
        var actionContainerPairs = owner.Actions.Zip(_actionContainers, Tuple.Create);
        foreach (var (action, container) in actionContainerPairs)
        {
            container.Initialize(action.Chance, action.ToString(), () => action.Invoke(holder, character));
            container.ActionCalled += Close;
        }
    }
}