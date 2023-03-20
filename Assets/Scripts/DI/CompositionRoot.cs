using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private PathMovement _pathMovement;
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindMovement();
    }

    private void BindMovement()
    {
        var pathfinder = new TileablePathfinder(_map);
        _pathMovement.Constructor(pathfinder);
        _playerInputHandler.Constructor(_pathMovement, _camera);
    }
}
