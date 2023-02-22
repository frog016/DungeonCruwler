using System.Collections.Generic;
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
        var routs = new Dictionary<Vector3, Vector3?> { [start] = null };
        var queue = new Queue<Vector3>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            foreach (var neighbor in _map.GetNeighbors(current))
            {
                var next = neighbor.Position;
                if (routs.ContainsKey(next)) 
                    continue;

                routs[next] = current;
                queue.Enqueue(next);
            }

            if (routs.ContainsKey(end)) 
                break;
        }

        return CreatePath(routs, end)
            .Reverse();
    }

    private static IEnumerable<Vector3> CreatePath(IReadOnlyDictionary<Vector3, Vector3?> routs, Vector3 end)
    {
        var pathItem = new Vector3?(end);
        while (pathItem != null)
        {
            yield return pathItem.Value;
            pathItem = routs[pathItem.Value];
        }
    }
}