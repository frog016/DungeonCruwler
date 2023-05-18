using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(IInterruptible))]
public class PlayerMovementHandler : MovementHandler
{
    [SerializeField] private LayerMask _layer;

    private Camera _camera;
    private IInterruptible _interruptible;

    [Inject]
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

    public override void OnTurnStarted()
    {
        _interruptible.Interrupted = false;
    }

    public override void OnTurnEnded()
    {
        base.OnTurnEnded();
        _interruptible.Interrupted = true;
    }

    protected override bool IsNextPointUnreachable(IEnumerator next)
    {
        return _interruptible.Interrupted || base.IsNextPointUnreachable(next);
    }

    protected override bool TryGetPoint(out Vector3 point)
    {
        var result = _camera.ScreenPointToHit(Input.mousePosition, _layer, out var hit);
        point = hit.transform.position;
        return result;
    }
}
