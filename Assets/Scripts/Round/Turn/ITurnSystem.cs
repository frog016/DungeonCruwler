using System;

public interface ITurnSystem
{
    ITurnEntity Current { get; }
    event Action RoundEnded;
    void Next();
}