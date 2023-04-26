using System.Linq;
using UnityEngine;

public class AIMovementHandler : MovementHandler
{
    [SerializeField] private Map _map;

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
        point = neighbors[index].Position;
        return true;
    }
}