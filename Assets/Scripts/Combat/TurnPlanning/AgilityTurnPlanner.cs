using System.Collections.Generic;
using System.Linq;

public class AgilityTurnPlanner : ITurnPlanner
{
    public IEnumerable<T> PlaneTurnSequence<T>(T[] entities) where T : IStatsUser
    {
        return entities
            .OrderBy(entity => entity.Stats.GetStat(StatType.Agility))
            .Reverse();
    }
}