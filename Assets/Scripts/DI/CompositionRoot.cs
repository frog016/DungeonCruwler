using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private PathMovement _pathMovement;
    [SerializeField] private PlayerMovementHandler _playerMovementHandler;

    [Header("Player")]
    [SerializeField] private Character _player;
    [SerializeField] private EventActivator _activator;
    [SerializeField] private HiddenObjectDetector _detector;

    [Header("Round")]
    [SerializeField] private Round _round;
    [SerializeField] private TurnEntity[] _entities;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindMovement();
        BindPlayer();
        BindRound();
    }

    private void BindMovement()
    {
        var pathfinder = new TileablePathfinder(_map);
        _pathMovement.Constructor(pathfinder);
        _playerMovementHandler.Constructor(_camera);
    }

    private void BindPlayer()
    {
        _activator.Constructor(_player);
        _detector.Constructor(_player);
    }

    private void BindRound()
    {
        _round.Constructor(_entities);
    }
}
