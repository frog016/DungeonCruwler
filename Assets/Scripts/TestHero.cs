using UnityEngine;

public class TestHero : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private PathMovement _movement;
    [SerializeField] private Camera _camera;

    private IPathfinder _pathfinder;

    private void Awake()
    {
        _pathfinder = new TileablePathfinder(_map);
        _movement.Constructor(_pathfinder);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                _movement.Move(hit.point);
            }
        }
    }
}
