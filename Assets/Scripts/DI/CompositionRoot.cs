using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private PathMovement _pathMovement;
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    [Header("Player")]
    [SerializeField] private Character _player;
    [SerializeField] private EventActivator _activator;
    [SerializeField] private HiddenObjectDetector _detector;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindMovement();
        BindPlayer();
    }

    private void BindMovement()
    {
        var pathfinder = new TileablePathfinder(_map);
        _pathMovement.Constructor(pathfinder);
        _playerInputHandler.Constructor(_pathMovement, _camera);
    }

    private void BindPlayer()
    {
        _activator.Constructor(_player);
        _detector.Constructor(_player);
    }
}
