using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private IMovement _movement;
    private Camera _camera;

    public void Constructor(IMovement movement, Camera camera)
    {
        _movement = movement;
        _camera = camera;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            HandleMovement(Input.mousePosition);
    }

    private void HandleMovement(Vector3 screenPoint)
    {
        if (_camera.ScreenPointToHit(screenPoint, out var hit))
            _movement.Move(hit.point);
    }
}
