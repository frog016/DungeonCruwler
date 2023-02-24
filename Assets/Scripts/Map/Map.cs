using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour, ITileableMap
{
    [SerializeField] private Grid _grid;

    private readonly Dictionary<Vector3Int, ITile> _map = new Dictionary<Vector3Int, ITile>();

    public void Add(ITile tile)
    {
        var position = ToCellPosition(tile.Position);
        _map[position] = tile;
    }

    public void Remove(ITile tile)
    {
        var position = ToCellPosition(tile.Position);
        if (!_map.ContainsKey(position))
            throw new ArgumentException($"Map doesn't contains tile {tile}.");

        _map.Remove(position);
    }

    public ITile GetTile(Vector3 tilePosition)
    {
        var position = ToCellPosition(tilePosition);
        return _map[position];
    }

    public IEnumerable<ITile> GetNeighbors(Vector3 tilePosition)
    {
        var position = ToCellPosition(tilePosition);
        var directions = VectorExtensions.Directions2Int
            .Select(vector => vector.ToVector3Int());

        foreach (var direction in directions)
            if (_map.TryGetValue(position + direction, out var neighbor))
                yield return neighbor;
    }

    public IEnumerable<ITile> GetTiles()
    {
        return _map
            .Select(pair => pair.Value)
            .AsEnumerable();
    }

    private Vector3Int ToCellPosition(Vector3 position)
    {
        return _grid.WorldToCell(position);
    }
}