using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour, ITileableMap
{
    [SerializeField] private Grid _grid;

    public Vector3 TileSize => _grid.cellSize;
    public Vector3 Center { get; private set; }
    public Vector3Int Size { get; private set; }

    private readonly Dictionary<Vector3Int, ITile> _map = new Dictionary<Vector3Int, ITile>();

    public void Constructor(ITile[] tiles)
    {
        foreach (var tile in tiles)
        {
            var position = WorldToLocal(tile.Position);
            _map[position] = tile;
        }

        RecalculateBounds();
    }

    public void Add(ITile tile)
    {
        var position = WorldToLocal(tile.Position);
        _map[position] = tile;

        RecalculateBounds();
    }

    public void Remove(ITile tile)
    {
        var position = WorldToLocal(tile.Position);
        if (!_map.ContainsKey(position))
            throw new ArgumentException($"Map doesn't contains tile {tile}.");

        _map.Remove(position);
        RecalculateBounds();
    }

    public ITile GetTile(Vector3 tilePosition)
    {
        var position = WorldToLocal(tilePosition);
        return _map[position];
    }

    public IEnumerable<ITile> GetNeighbors(Vector3 tilePosition)
    {
        var position = WorldToLocal(tilePosition);
        var directions = VectorExtensions.Directions2Int
            .Select(vector => new Vector3Int(vector.x, 0, vector.y));

        foreach (var direction in directions)
            if (_map.TryGetValue(position + direction, out var neighbor))
                yield return neighbor;
    }

    public IEnumerable<ITile> GetAll()
    {
        return _map
            .Select(pair => pair.Value);
    }

    public Vector3 LocalToWorld(Vector3Int local)
    {
        var gridPosition = _grid.GetCellCenterWorld(local);
        return new Vector3(gridPosition.x, 0, gridPosition.y);
    }

    public Vector3Int WorldToLocal(Vector3 world)
    {
        var gridPosition = _grid.WorldToCell(world);
        return new Vector3Int(gridPosition.x, 0, gridPosition.y);
    }

    public bool InBorders(Vector3 position)
    {
        var halfSize = Size.ToVector3() / 2;
        var minPoint = Center - halfSize;
        var maxPoint = Center + halfSize;
        return InBordersByCoordinate(position.x, minPoint.x, maxPoint.x) &&
               InBordersByCoordinate(position.z, minPoint.z, maxPoint.z);
    }

    private void RecalculateBounds()
    {
        var minTilePosition = _map.Values.Select(tile => tile.Position).MinBy();
        var maxTilePosition = _map.Values.Select(tile => tile.Position).MaxBy();

        Center = (maxTilePosition + minTilePosition) / 2f;
        Size = (maxTilePosition - minTilePosition)
        .Absolute()
        .ToVector3IntUp()
        + Vector3Int.one;
    }

    private static bool InBordersByCoordinate(float position, float min, float max)
    {
        return position >= min && position <= max;
    }
}