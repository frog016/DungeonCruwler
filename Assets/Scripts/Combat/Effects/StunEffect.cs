public class StunEffect<T> : TemporaryEffect<T> where T : ICharacter
{
    //+1 is to keep the stun going throughout the turn.
    //If duration = 1, then the stun will tick, after which it will immediately disappear and have no effect.
    public StunEffect(int duration, T target) : base(duration + 1, target)
    {
    }

    protected override void UseEffect()
    {
        _target.Interrupted = true;
    }

    protected override void End()
    {
        _target.Interrupted = false;
    }
}