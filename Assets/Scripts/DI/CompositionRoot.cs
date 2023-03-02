using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private PathMovement _pathMovement;
    [SerializeField] private CharacterInputHandler _characterInputHandler;

    [SerializeField] private Character _character;
    [SerializeField] private ScriptableStatModifier[] _modifiers;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindMovement();
        BindStats();
    }

    private void BindMovement()
    {
        var pathfinder = new TileablePathfinder(_map);
        _pathMovement.Constructor(pathfinder);
        _characterInputHandler.Constructor(_pathMovement, _camera);
    }

    private void BindStats()
    {
        var stats = new Stats();
        _character.Constructor(stats, _modifiers);
    }
}
