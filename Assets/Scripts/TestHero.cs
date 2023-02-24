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
                var target = new Vector3((int)hit.point.x, 0, (int)hit.point.z) + new Vector3(Mathf.Sign(hit.point.x) * 1, 0, Mathf.Sign(hit.point.z) * 1) / 2;
                _movement.Move(target);
            }
        }
    }
}
