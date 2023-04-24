using System;

public struct CharacterAction
{
    public readonly Action Action;
    public int Cost { get; private set; }

    public CharacterAction(int cost, Action action)
    {
        Action = action;
        Cost = cost;
    }
}
