using System;
using System.Linq;
using UnityEngine;

public class ShadowCastingVisibleArea : IVisibleArea
{
    private readonly ITileableMap _map;

    public ShadowCastingVisibleArea(ITileableMap map)
    {
        _map = map;
    }

    public void DiscoverArea(Vector3 position, int radius)
    {
        var origin = _map.WorldToLocal(position);
        MarkVisible(origin);

        var cardinals = Enum
            .GetValues(typeof(Quadrant.Direction))
            .Cast<Quadrant.Direction>();
        foreach (var cardinal in cardinals)
        {
            var quadrant = new Quadrant(cardinal, origin);
            var row = new Row(1, radius, -1, 1);
            ScanAreaPart(quadrant, row, radius);
        }
    }

    private void ScanAreaPart(Quadrant quadrant, Row row, int radius)
    {
        Vector3Int? previousPosition = null;
        foreach (var rowPosition in row.GetMapPositions())
        {
            var position = quadrant.Transform(rowPosition);
            if (IsWall(quadrant, rowPosition) || IsSymmetric(row, rowPosition))
                DiscoverTile(quadrant, rowPosition, radius);

            if (IsWall(quadrant, previousPosition) && IsFloor(quadrant, rowPosition))
                row.StartSlope = GetSlope(rowPosition);

            if (IsFloor(quadrant, previousPosition) && IsWall(quadrant, rowPosition) && row.TryNext(out var nextRow))
            {
                nextRow.EndSlope = GetSlope(rowPosition);
                ScanAreaPart(quadrant, nextRow, radius);
            }

            previousPosition = rowPosition;
        }

        if (IsFloor(quadrant, previousPosition) && row.TryNext(out var next))
            ScanAreaPart(quadrant, next, radius);
    }

    private void DiscoverTile(Quadrant quadrant, Vector3Int tile, int radius)
    {
        if (tile.magnitude > radius)
            return;

        MarkVisible(quadrant.Transform(tile));
    }

    private bool IsWall(Quadrant quadrant, Vector3Int? point) => IsTileType(quadrant, point, TileType.Obstacle);

    private bool IsFloor(Quadrant quadrant, Vector3Int? point) => IsTileType(quadrant, point, TileType.Platform);

    private bool IsTileType(Quadrant quadrant, Vector3Int? point, TileType type)
    {
        if (!point.HasValue)
            return false;

        var worldPosition = _map.LocalToWorld(quadrant.Transform(point.Value));
        if (!_map.InBorders(worldPosition))
            return true;

        var tile = _map.GetTile(worldPosition);
        return tile.TileType == type;
    }

    private void MarkVisible(Vector3Int tile)
    {
        var position = _map.LocalToWorld(tile);
        if (!_map.InBorders(position))
            return;

        _map.GetTile(position).Visibility = VisibilityType.Discovered;
    }

    private static float GetSlope(Vector3Int tile)
    {
        return (2f * tile.z - 1) / (2f * tile.x);
    }

    private static bool IsSymmetric(Row row, Vector3Int tile)
    {
        return tile.z >= row.Depth * row.StartSlope && tile.z <= row.Depth * row.EndSlope;
    }
}