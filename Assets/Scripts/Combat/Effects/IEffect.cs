public interface IEffect
{
    int Duration { get; set; }
    void Apply();
}