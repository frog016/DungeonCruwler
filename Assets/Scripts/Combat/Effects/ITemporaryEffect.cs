public interface ITemporaryEffect : IEffect
{
    bool Applied { get; }
    void Remove();
}