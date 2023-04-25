using UnityEngine;

[RequireComponent(typeof(IStatsUser))]
public class Energy : MonoBehaviour
{
    public int CurrentAmount { get; private set; }

    private int _limit;

    private void Start()
    {
        var stats = GetComponent<IStatsUser>();

        _limit = stats.Stats.GetStat(StatType.Speed);
        CurrentAmount = _limit;
    }

    public bool TrySpend(int cost)
    {
        if (cost > CurrentAmount)
            return false;

        CurrentAmount -= cost;
        return true;
    }

    public void Restore()
    {
        CurrentAmount = _limit;
    }
}
