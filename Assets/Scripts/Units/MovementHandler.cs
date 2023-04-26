using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IPathMovement), typeof(ITurnEntity))]
public abstract class MovementHandler : MonoBehaviour
{
    [SerializeField] private Round _round;

    protected IPathMovement _movement;
    protected ITurnEntity _entity;
    protected Coroutine _moveCoroutine;

    protected virtual void Awake()
    {
        _movement = GetComponent<IPathMovement>();
        _entity = GetComponent<ITurnEntity>();
        
    }

    private void OnEnable()
    {
        _round.TurnStarted += StartMovement;
        _round.TurnEnded += EndMovement;
    }

    private void OnDisable()
    {
        _round.TurnStarted -= StartMovement;
        _round.TurnEnded -= EndMovement;
    }

    protected virtual void StartMovement(ITurnEntity entity)
    {
    }

    protected virtual void EndMovement(ITurnEntity entity)
    {
        if (entity.Team != _entity.Team)
            return;
        
        _entity.Energy.Restore();
    }

    protected abstract bool TryGetPoint(out Vector3 point);

    protected IEnumerator HandleMovement()
    {
        if (!TryGetPoint(out var point))
            yield break;

        _movement.SetDestination(point, _entity.Energy.CurrentAmount);
        while (true)
        {
            var next = _movement.MoveNext();
            yield return next;
            if (IsNextPointUnreachable(next))
                yield break;
        }
    }

    protected virtual bool IsNextPointUnreachable(IEnumerator next)
    {
        return next.Current != null && !_entity.Energy.TrySpend(1);
    }

    protected void RestartCoroutine(IEnumerator enumerator)
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

        _moveCoroutine = StartCoroutine(enumerator);
    }
}