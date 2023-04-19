using UnityEngine;

[RequireComponent(typeof(ITurnBasedCombat))]
public class CombatEffectInvoker : EffectInvoker<ITurnBasedCombat>
{
    private void Awake()
    {
        _eventSystem = GetComponent<ITurnBasedCombat>();
        _eventSystem.TurnStarted += InvokeAllEffect;
    }

    private void OnDestroy()
    {
        _eventSystem.TurnStarted -= InvokeAllEffect;
    }
}