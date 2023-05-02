public interface IConsumableResource
{
    int Amount { get; }
    bool TrySpend(int cost);
    void Restore();
}