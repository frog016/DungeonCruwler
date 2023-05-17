using System.Collections.Generic;

public interface ITurnPlanner
{
    IEnumerable<T> PlaneTurnSequence<T>(T[] entities) where T : IStatsUser;
}