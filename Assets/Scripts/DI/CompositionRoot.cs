using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Camera _camera;
    [SerializeField] private PathMovement _pathMovement;
    [SerializeField] private CharacterInputHandler _characterInputHandler;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        var pathfinder = new TileablePathfinder(_map);
        _pathMovement.Constructor(pathfinder);
        _characterInputHandler.Constructor(_pathMovement, _camera);
    }
}
