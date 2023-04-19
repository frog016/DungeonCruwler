using System.Linq;
using UnityEngine;

public abstract class EffectInvoker<TEventSystem> : MonoBehaviour
{
    protected TEventSystem _eventSystem;

    protected static void InvokeAllEffect(IEffectApplier[] appliers)
    {
        foreach (var applier in appliers)
        {
            var effects = applier.Effects.ToArray();
            foreach (var effect in effects)
            {
                CheckTemporaryEffect(applier, effect);
                CheckTickableEffect(applier, effect);
            }
        }
    }

    private static void CheckTemporaryEffect(IEffectApplier applier, IEffect effect)
    {
        if (!TryGetEffect(effect, out ITemporaryEffect temporaryEffect))
            return;

        if (temporaryEffect.Applied)
        {
            temporaryEffect.Duration--;
            if (temporaryEffect.Duration != 0)
                return;

            temporaryEffect.Remove();
            applier.RemoveEffect(temporaryEffect);
        }
        else
        {
            temporaryEffect.Apply();
        }
    }

    private static void CheckTickableEffect(IEffectApplier applier, IEffect effect)
    {
        if (!TryGetEffect(effect, out ITickableEffect temporaryEffect))
            return;

        temporaryEffect.Duration--;
        temporaryEffect.Apply();
        if (temporaryEffect.Duration != 0)
            return;

        applier.RemoveEffect(temporaryEffect);
    }

    private static bool TryGetEffect<TEffect>(IEffect effect, out TEffect tEffect) where TEffect : IEffect
    {
        tEffect = default;
        try
        {
            tEffect = (TEffect)effect;
        }
        catch
        {
            return false;
        }

        return true;
    }
}