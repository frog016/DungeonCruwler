using UnityEngine;

public abstract class VarietyEventAction : ScriptableEventAction
{
    [SerializeField] protected StatType _statToCheck;

    protected bool TryOvercomeThreshold(IInteractableEvent interactableEvent, ICharacter target)
    {
        var avoidValue = Dice.RollD20() + GetModifier(target);
        var threshold = interactableEvent.ComplexityClass;

        Debug.Log($"{target} rolled {avoidValue}.");
        return avoidValue >= threshold;
    }

    private int GetModifier(IStatsUser character)
    {
        return character.Stats.GetStat(_statToCheck) / 2;
    }
}