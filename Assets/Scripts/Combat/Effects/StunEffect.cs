public class StunEffect : TemporaryEffect
{
    //+1 is to keep the stun going throughout the turn.
    //If duration = 1, then the stun will tick, after which it will immediately disappear and have no effect.
    public StunEffect(int duration, ICharacter target) : base(duration + 1, target)
    {
    }

    public override void Apply()
    {
        base.Apply();
        _target.Interrupted = true;
    }

    public override void Remove()
    {
        _target.Interrupted = false;
    }
}