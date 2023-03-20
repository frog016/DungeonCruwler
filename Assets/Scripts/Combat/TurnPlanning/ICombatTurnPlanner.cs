using System.Collections.Generic;

public interface ICombatTurnPlanner
{
    IEnumerable<T> PlaneTurnSequence<T>(T[] entities) where T : IStatsUser;
}