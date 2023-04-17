using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileableVisibleArea
{
    private readonly ITileableMap _map;
    private ShadowCastingVisibleArea _shadowCasting;

    public TileableVisibleArea(ITileableMap map)
    {
        _map = map;
    }

    public void DiscoverTiles(Vector3 position, int radius)
    {
        var origin = _map.WorldToLocal(position);
        _shadowCasting ??= new ShadowCastingVisibleArea(_map);
        _shadowCasting.Compute(origin, radius);
    }
}

public class ShadowCastingVisibleArea
{
    private readonly ITileableMap _map;

    public ShadowCastingVisibleArea(ITileableMap map)
    {
        _map = map;
    }

    public void Compute(Vector3Int origin, int radius)
    {
        MarkVisible(origin);

        var cardinals = Enum
            .GetValues(typeof(Quadrant.Direction))
            .Cast<Quadrant.Direction>();
        foreach (var cardinal in cardinals)
        {
            var quadrant = new Quadrant(cardinal, origin);
            var row = new Row(1, radius, -1, 1);
            ScanRecursive(quadrant, row, radius);
        }
    }

    private void ScanRecursive(Quadrant quadrant, Row row, int radius)
    {
        Vector3Int? previousPosition = null;
        foreach (var position in row.GetMapPositions())
        {
            if (IsWall(quadrant, position) || IsSymmetric(row, position))
                Reveal(quadrant, position, radius);

            if (IsWall(quadrant, previousPosition) && IsFloor(quadrant, position))
                row.StartSlope = Slope(position);

            if (IsFloor(quadrant, previousPosition) && IsWall(quadrant, position) && row.TryNext(out var nextRow))
            {
                nextRow.EndSlope = Slope(position);
                ScanRecursive(quadrant, nextRow, radius);
            }

            previousPosition = position;
        }

        if (IsFloor(quadrant, previousPosition) && row.TryNext(out var next))
            ScanRecursive(quadrant, next, radius);
    }

    private void Reveal(Quadrant quadrant, Vector3Int tile, int radius)
    {
        if (tile.magnitude > radius)
            return;

        MarkVisible(quadrant.Transform(tile));
    }

    private bool IsWall(Quadrant quadrant, Vector3Int? tile)
    {
        if (!tile.HasValue)
            return false;

        var position = _map.LocalToWorld(quadrant.Transform(tile.Value));
        if (!_map.InBorders(position))
            return false;

        var mapTile = _map.GetTile(position);
        return mapTile.TileType == TileType.Obstacle;
    }

    private bool IsFloor(Quadrant quadrant, Vector3Int? tile)
    {
        if (!tile.HasValue)
            return false;

        var position = _map.LocalToWorld(quadrant.Transform(tile.Value));
        if (!_map.InBorders(position))
            return true;

        var mapTile = _map.GetTile(position);
        return mapTile.TileType == TileType.Platform;
    }

    private float Slope(Vector3Int tile)
    {
        return (2f * tile.z - 1) / (2f * tile.x);
    }

    private bool IsSymmetric(Row row, Vector3Int tile)
    {
        return tile.z >= row.Depth * row.StartSlope && tile.z <= row.Depth * row.EndSlope;
    }

    private void MarkVisible(Vector3Int tile)
    {
        var position = _map.LocalToWorld(tile);
        if (!_map.InBorders(position))
            return;

        _map.GetTile(position).Visibility = VisibilityType.Discovered;
    }

    public readonly struct Quadrant
    {
        public enum Direction { North, East, South, West }

        public readonly Direction Cardinal;
        public readonly Vector3Int Origin;

        public Quadrant(Direction cardinal, Vector3Int origin)
        {
            Cardinal = cardinal;
            Origin = origin;
        }

        public Vector3Int Transform(Vector3Int tile)
        {
            var direction = new Vector3Int();
            switch (Cardinal)
            {
                case Direction.North:
                    direction = new Vector3Int(tile.z, 0, -tile.x);
                    break;
                case Direction.South:
                    direction = new Vector3Int(tile.z, 0, tile.x);
                    break;
                case Direction.East:
                    direction = new Vector3Int(tile.x, 0, tile.z);
                    break;
                case Direction.West:
                    direction = new Vector3Int(-tile.x, 0, tile.z);
                    break;
            }

            return Origin + direction;
        }
    }

    public struct Row
    {
        public int Depth { get; set; }
        public float StartSlope { get; set; }
        public float EndSlope { get; set; }

        private readonly int _maxDepth;

        public Row(int depth, int maxDepth, float startSlope, float endSlope)
        {
            _maxDepth = maxDepth;
            Depth = depth;
            StartSlope = startSlope;
            EndSlope = endSlope;
        }

        public IEnumerable<Vector3Int> GetMapPositions()
        {
            var minColumn = Mathf.RoundToInt(Depth * StartSlope);
            var maxColumn = Mathf.RoundToInt(Depth * EndSlope);

            for (var column = minColumn; column <= maxColumn; column++)
                yield return new Vector3Int(Depth, 0, column);
        }

        public bool TryNext(out Row row)
        {
            row = new Row(Depth + 1, _maxDepth, StartSlope, EndSlope);
            return row.Depth <= _maxDepth;
        }
    }
}