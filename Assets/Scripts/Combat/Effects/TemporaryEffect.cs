public abstract class TemporaryEffect : ITemporaryEffect
{
    public bool Applied { get; private set; }
    public int Duration { get; set; }

    protected readonly ICharacter _target;

    protected TemporaryEffect(int duration, ICharacter target)
    {
        Duration = duration;
        _target = target;
    }

    public virtual void Apply()
    {
        Applied = true;
    }

    public abstract void Remove();
}