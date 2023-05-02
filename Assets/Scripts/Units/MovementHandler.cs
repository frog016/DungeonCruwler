using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IPathMovement), typeof(IConsumableResource))]
public abstract class MovementHandler : MonoBehaviour, ITurnEntity
{
    public IConsumableResource Resource { get; private set; }

    protected IPathMovement _movement;
    protected Coroutine _movementRoutine;

    protected virtual void Awake()
    {
        Resource = GetComponent<IConsumableResource>();
        _movement = GetComponent<IPathMovement>();
    }

    public virtual void OnTurnStarted()
    {
        RestartCoroutine(HandleMovement());
    }

    public virtual void OnTurnEnded()
    {
        Resource.Restore();
    }

    protected virtual bool IsNextPointUnreachable(IEnumerator next)
    {
        return next.Current != null && ! Resource.TrySpend(1);
    }

    protected abstract bool TryGetPoint(out Vector3 point);

    protected IEnumerator HandleMovement()
    {
        if (!TryGetPoint(out var point))
            yield break;

        _movement.SetDestination(point, Resource.Amount);
        while (true)
        {
            var next = _movement.MoveNext();
            yield return next;
            if (IsNextPointUnreachable(next))
                yield break;
        }
    }

    protected void RestartCoroutine(IEnumerator enumerator)
    {
        if (_movementRoutine != null)
            StopCoroutine(_movementRoutine);

        _movementRoutine = StartCoroutine(enumerator);
    }
}