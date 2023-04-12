using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilableVisibleArea
{
    public void DiscoverTiles(ITileableMap map, FogDiscoverer discoverer)
    {
        var position = map.WorldToLocal(discoverer.transform.position);

        map.GetTile(discoverer.transform.position).Visibility = VisibilityType.Discovered;
        var tilesInArea = GetTilesInArea(map, position, discoverer.ViewRadius, discoverer.RaysCount).ToHashSet();
        foreach (var tile in tilesInArea)
            tile.Visibility = VisibilityType.Discovered;
    }

    private static IEnumerable<ITile> GetTilesInArea(ITileableMap map, Vector3Int position, int radius, int raysCount)
    {
        var stepAngle = 360f / raysCount;
        var endRayPoint = position + Vector3Int.forward * radius;

        yield return map.GetTile(map.LocalToWorld(position));

        for (var i = 0; i < raysCount; i++)
        {
            var intersectedTiles = LaunchRay(position, endRayPoint)
                .Select(map.LocalToWorld)
                .Where(map.InBorders)
                .Select(map.GetTile)
                .TakeWhile(tile => tile.TileType != TileType.Obstacle);

            foreach (var tile in intersectedTiles)
                yield return tile;

            endRayPoint = position + (endRayPoint - position).RotateY(stepAngle * Mathf.Deg2Rad);
        }
    }

    private static IEnumerable<Vector3Int> LaunchRay(Vector3Int from, Vector3Int to)
    {
        var delta = to - from;
        var absoluteDelta = delta.Absolute();
        var acceleration = 0;
        if (absoluteDelta.x >= absoluteDelta.z)
        {
            var z = from.z;
            var direction = delta.z.Sign();
            var step = (int)Mathf.Sign(delta.x);
            for (var x = from.x; delta.x > 0 ? x <= to.x : x >= to.x; x += step)
            {
                yield return new Vector3Int(x, 0, z);

                acceleration += absoluteDelta.z;
                if (acceleration < absoluteDelta.x)
                    continue;

                acceleration -= absoluteDelta.x;
                z += direction;
            }
        }
        else
        {
            var x = from.x;
            var direction = delta.x.Sign();
            var step = (int)Mathf.Sign(delta.z);
            for (var z = from.z; delta.z > 0 ? z <= to.z : z >= to.z; z += step)
            {
                yield return new Vector3Int(x, 0, z);

                acceleration += absoluteDelta.x;
                if (acceleration < absoluteDelta.z)
                    continue;

                acceleration -= absoluteDelta.z;
                x += direction;
            }
        }
    }
}