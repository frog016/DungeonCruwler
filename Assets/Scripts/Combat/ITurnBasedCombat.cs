using System;
using System.Collections.Generic;

public interface ITurnBasedCombat
{
    event Action<ICombatEntity[]> TurnStarted; 
    event Action<ICombatEntity> CombatEnded;
    public IEnumerable<ICombatEntity> Fighters { get; }
    void Initialize(ICharacter[] characters);
    void Launch();
}