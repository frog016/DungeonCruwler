using System;

public interface IStats
{
    event Action<Stat, float> ValueChanged;
    void ChangeStatByValue(Stat stat, float delta);
    float GetStatValue(Stat stat);
}