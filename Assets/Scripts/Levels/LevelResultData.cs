public struct LevelResultData
{
    public readonly (IStats, ICompositeStats)[] PlayerStats;
    public readonly object Reward;
    public readonly bool IsWin;

    public LevelResultData((IStats, ICompositeStats)[] playerStats, object reward, bool isWin)
    {
        PlayerStats = playerStats;
        Reward = reward;
        IsWin = isWin;
    }
}