using UnityEngine;

public class PlayerMovementHandler : MovementHandler
{
    [SerializeField] private LayerMask _layer;

    private Camera _camera;

    private bool _canMove;

    public void Constructor(Camera camera)
    {
        _camera = camera;
    }

    private void Update()
    {
        if (!_canMove)
            return;

        if (Input.GetMouseButtonDown(1))
            RestartCoroutine( HandleMovement());
    }

    protected override void StartMovement(ITurnEntity entity)
    {
        _canMove = true;
    }

    protected override void EndMovement(ITurnEntity entity)
    {
        base.EndMovement(entity);
        _canMove = false;
    }

    protected override bool TryGetPoint(out Vector3 point)
    {
        var result = _camera.ScreenPointToHit(Input.mousePosition, _layer, out var hit);
        point = hit.transform.position;
        return result;
    }
}
