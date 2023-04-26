using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IInterruptible))]
public class PlayerMovementHandler : MovementHandler
{
    [SerializeField] private LayerMask _layer;

    private Camera _camera;
    private IInterruptible _interruptible;

    public void Constructor(Camera camera)
    {
        _camera = camera;
    }

    protected override void Awake()
    {
        base.Awake();
        _interruptible = GetComponent<IInterruptible>();
    }

    private void Update()
    {
        if (_interruptible.Interrupted)
            return;

        if (Input.GetMouseButtonDown(1))
            RestartCoroutine( HandleMovement());
    }

    protected override void StartMovement(ITurnEntity entity)
    {
        _interruptible.Interrupted = false;
    }

    protected override void EndMovement(ITurnEntity entity)
    {
        base.EndMovement(entity);
        _interruptible.Interrupted = true;
    }

    protected override bool TryGetPoint(out Vector3 point)
    {
        var result = _camera.ScreenPointToHit(Input.mousePosition, _layer, out var hit);
        point = hit.transform.position;
        return result;
    }

    protected override bool IsNextPointUnreachable(IEnumerator next)
    {
        return _interruptible.Interrupted || base.IsNextPointUnreachable(next);
    }
}
