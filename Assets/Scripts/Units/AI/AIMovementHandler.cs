using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovementHandler : MovementHandler
{
    [SerializeField] private Area _loiteringArea;
    [SerializeField] private Map _map;

    protected override void Awake()
    {
        base.Awake();
        _loiteringArea.Center = transform.position;
    }

    protected override void StartMovement(ITurnEntity entity)
    {
        if (entity.Team != _entity.Team)
            return;

        RestartCoroutine(HandleMovement());
    }

    protected override bool TryGetPoint(out Vector3 point)
    {
        point = default;
        var neighbors = _map
            .GetNeighbors(transform.position)
            .Where(tile => tile.TileType == TileType.Platform)
            .ToArray();

        if (neighbors.Length == 0)
            return false;

        var index = Random.Range(0, neighbors.Length);
        point = _loiteringArea.Clamp(neighbors[index].Position);
        return true;
    }
}