using System;

public interface ITurnBasedCombat
{
    event Action<CombatStateMachine[]> TurnStarted; 
    event Action<CombatStateMachine> CombatEnded; 
    void StartCombat();
}