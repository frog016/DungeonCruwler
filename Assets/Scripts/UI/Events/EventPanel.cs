using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class EventPanel : UIPanel
{
    [SerializeField] private TextMeshProUGUI _eventNameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private EventActionContainer[] _actionContainers;

    public void Initialize(EventBehaviour owner, ICharacter character)
    {
        _eventNameText.text = owner.DescriptionData.Name;
        _descriptionText.text = owner.DescriptionData.Description;

        var actionContainerPairs = owner.Actions.Cast<ScriptableEventAction>().Zip(_actionContainers, Tuple.Create);
        foreach (var (action, container) in actionContainerPairs)
        {
            var chance = action is NegativeEventAction negativeAction
                ? negativeAction.CalculateChance(owner as HiddenEventBehaviour, character)
                : 1f;

            container.Initialize(ConvertChanceToPercent(chance), action.DescriptionData.Name, () => action.Invoke(owner, character));
            container.ActionCalled += Close;
        }
    }

    private int ConvertChanceToPercent(float chance)
    {
        return Mathf.RoundToInt(chance * 100);
    }
}