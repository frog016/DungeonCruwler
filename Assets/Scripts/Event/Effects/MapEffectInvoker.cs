using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Round))]
public class MapEffectInvoker : EffectInvoker<Round>
{
    [SerializeField] private DamageableUnit[] _units;

    private void Awake()
    {
        _eventSystem = GetComponent<Round>();
        _eventSystem.TurnStarted += OnTurnStarted;
    }

    private void OnDestroy()
    {
        _eventSystem.TurnStarted -= OnTurnStarted;
    }

    private void OnTurnStarted(ITurnEntity entity)
    {
        var unit = _units.FirstOrDefault(u => u.GetComponent<Energy>() == entity.Energy);
        if (unit == null)
            return;

        InvokeAllEffect(new IEffectApplier[] { unit });
    }
}