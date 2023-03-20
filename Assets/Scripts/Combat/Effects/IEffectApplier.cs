using System.Collections.Generic;

public interface IEffectApplier
{
    IEnumerable<ITickableEffect> Effects { get; }
    void ApplyEffect(ITickableEffect tickableEffect);
    void RemoveEffect(ITickableEffect tickableEffect);
}