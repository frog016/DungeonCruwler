using System.Collections.Generic;

public interface IEffectApplier
{
    IEnumerable<IEffect> Effects { get; }
    void ApplyEffect(IEffect temporaryEffect);
    void RemoveEffect(IEffect temporaryEffect);
}