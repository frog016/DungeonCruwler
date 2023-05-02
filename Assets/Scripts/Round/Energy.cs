using UnityEngine;

[RequireComponent(typeof(IStatsUser))]
public class Energy : MonoBehaviour, IConsumableResource
{
    public int Amount { get; private set; }

    private int _limit;

    private void Start()
    {
        var stats = GetComponent<IStatsUser>();

        _limit = stats.Stats.GetStat(StatType.Speed);
        Restore();
    }

    public bool TrySpend(int cost)
    {
        if (cost > Amount)
            return false;

        Amount -= cost;
        return true;
    }

    public void Restore()
    {
        Amount = _limit;
    }
}