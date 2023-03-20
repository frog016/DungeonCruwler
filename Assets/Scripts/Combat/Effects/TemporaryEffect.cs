using System;

public abstract class TemporaryEffect<T> : ITickableEffect where T : ICharacter
{
    protected readonly T _target;

    private int _duration;

    protected TemporaryEffect(int duration, T target)
    {
        _duration = duration;
        _target = target;
    }

    public int Tick()
    {
        UseEffect();
        _duration = Math.Max(_duration - 1, 0);
        if (_duration == 0)
            End();

        return _duration;
    }

    protected abstract void UseEffect();
    protected abstract void End();
}