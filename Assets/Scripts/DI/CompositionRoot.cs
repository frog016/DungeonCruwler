using System.Linq;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Map _map;
    [SerializeField] private PathMovement[] _pathMovements;

    [Header("Player")]
    [SerializeField] private Character _player;
    [SerializeField] private EventActivator _activator;
    [SerializeField] private HiddenObjectDetector _detector;
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovementHandler _playerMovementHandler;

    [Header("Round")]
    [SerializeField] private MapTurnSystem _mapTurnSystem;
    [SerializeField] private MonoBehaviour[] _entities;

    [Header("UI")]
    [SerializeField] private UIInventoryPanel _uiInventoryPanel;
    [SerializeField] private StatsPanel _statsPanel;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindMovement();
        BindPlayer();
        BindRound();
        BindUI();
    }

    private void BindMovement()
    {
        var pathfinder = new TileablePathfinder(_map);
        foreach (var pathMovement in _pathMovements)
            pathMovement.Constructor(pathfinder);
    }

    private void BindPlayer()
    {
        _activator.Constructor(_player);
        _detector.Constructor(_player);
        _playerMovementHandler.Constructor(_camera);
    }

    private void BindRound()
    {
        var entities = _entities
            .Cast<ITurnEntity>();

        _mapTurnSystem.Constructor(entities);
    }

    private void BindUI()
    {
        _uiInventoryPanel.Constructor(_player);
        _statsPanel.Constructor(_player);
    }
}