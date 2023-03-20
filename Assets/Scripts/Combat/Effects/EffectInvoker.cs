using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ITurnBasedCombat))]
public class EffectInvoker : MonoBehaviour
{
    private ITurnBasedCombat _turnBasedCombat;

    private void Awake()
    {
        _turnBasedCombat = GetComponent<ITurnBasedCombat>();
        _turnBasedCombat.TurnStarted += InvokeAllEffect;
    }

    private void OnDestroy()
    {
        _turnBasedCombat.TurnStarted -= InvokeAllEffect;
    }

    private static void InvokeAllEffect(IEffectApplier[] appliers)
    {
        foreach (var applier in appliers)
        {
            var effects = applier.Effects.ToArray();
            foreach (var effect in effects)
                if (effect.Tick() == 0)
                    applier.RemoveEffect(effect);
        }
    }
}