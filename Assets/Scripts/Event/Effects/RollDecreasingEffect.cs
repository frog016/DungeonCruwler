using UnityEngine;

[CreateAssetMenu(menuName = "Event/Trap/Effects/RollDecreasing", fileName = "RollDecreasingEffect")]
public class RollDecreasingEffect : ScriptableTemporaryEffect
{
    [SerializeField] private int _value;

    public override void Apply()
    {
        base.Apply();
        Dice.ChangeModifier(-_value);
    }

    public override void Remove()
    {
        base.Remove();
        Dice.ChangeModifier(_value);
    }
}