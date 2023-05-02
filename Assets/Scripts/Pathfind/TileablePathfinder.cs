﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileablePathfinder : IPathfinder
{
    private readonly ITileableMap _map;

    public TileablePathfinder(ITileableMap map)
    {
        _map = map;
    }

    public IEnumerable<Vector3> Find(Vector3 start, Vector3 end)
    {
        var startTile = _map.GetTile(start);
        var endTile = _map.GetTile(end);
        if (IsObstacle(endTile))
            yield break;

        var routs = new Dictionary<ITile, ITile> { [startTile] = null };
        var queue = new Queue<ITile>();
        queue.Enqueue(startTile);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            foreach (var neighbor in _map.GetNeighbors(current.Position))
            {
                if (IsObstacle(neighbor) || routs.ContainsKey(neighbor)) 
                    continue;

                routs[neighbor] = current;
                queue.Enqueue(neighbor);
            }

            if (routs.ContainsKey(endTile)) 
                break;
        }

        foreach (var point in CreatePath(routs, endTile).Reverse())
            yield return point;
    }

    private static bool IsObstacle(ITile tile)
    {
        return tile.TileType == TileType.Obstacle;
    }

    private static IEnumerable<Vector3> CreatePath(IReadOnlyDictionary<ITile, ITile> routs, ITile endTile)
    {
        var pathItem = endTile;
        while (pathItem != null)
        {
            yield return pathItem.Position;
            pathItem = routs[pathItem];
        }
    }
}