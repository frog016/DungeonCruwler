using UnityEngine;

public static class Dice
{
    public const int D4 = 4;
    public const int D6 = 6;
    public const int D20 = 20;
    public const int MinimalValue = 1;

    private static int _modifier;

    public static int Roll(Type diceType)
    {
        return Roll((int)diceType);
    }

    public static int Roll(int maxValue)
    {
        var rolledValue = Random.Range(MinimalValue, maxValue + 1);
        return Mathf.Max(0, rolledValue + _modifier);
    }

    public static int RollD4()
    {
        return Roll(D4);
    }

    public static int RollD20()
    {
        return Roll(D20);
    }

    public static void ChangeModifier(int value)
    {
        _modifier += value;
    }

    public enum Type
    {
        D4 = Dice.D4,
        D6 = Dice.D6,
        D20 = Dice.D20
    }
}