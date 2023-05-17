using System;

public interface IItem
{
    int StackSize { get; }
    void Activate(IStatsUser statsUser);
}