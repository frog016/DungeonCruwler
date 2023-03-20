using System;

public interface ITurnBasedCombat
{
    event Action<CombatStateMachine[]> TurnStarted; 
    void StartCombat();
}