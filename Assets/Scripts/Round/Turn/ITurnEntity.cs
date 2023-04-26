public interface ITurnEntity
{
    IConsumableResource Resource { get; }
    void OnTurnStarted();
    void OnTurnEnded();
}