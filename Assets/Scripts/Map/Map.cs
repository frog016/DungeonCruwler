using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour, ITileableMap
{
    [SerializeField] private Vector2Int _size;

    private Dictionary<Vector2, ITile> _map;

    private void Awake()
    {
        _map = CreateMap();
    }

    public void Add(ITile tile)
    {
        InBoundaries(tile.Position, out var position);
        _map[position] = tile;
    }

    public void Remove(ITile tile)
    {
        InBoundaries(tile.Position, out var position);
        _map[position] = null;
    }

    public IEnumerable<ITile> GetNeighbors(Vector3 tilePosition)
    {
        var tileCenter = new Vector3((int)tilePosition.x, 0, (int)tilePosition.z) + new Vector3(1, 0, 1) / 2;
        InBoundaries(tilePosition, out var position);
        foreach (var direction in VectorExtensions.Directions2)
            if (_map.TryGetValue(position + direction, out var neighbor) && neighbor != null)
                yield return neighbor;
    }

    public IEnumerable<ITile> GetTiles()
    {
        return _map
            .Select(pair => pair.Value)
            .AsEnumerable();
    }

    private Dictionary<Vector2, ITile> CreateMap()
    {
        var center = transform.position;
        var leftBottom = center - _size.ToVector3Plane() + new Vector3(1, 0, 1) / 2;

        var result = new Dictionary<Vector2, ITile>();
        for (var x = leftBottom.x; x < _size.x; x++)
            for (var z = leftBottom.z; z < _size.y; z++)
                result.Add(new Vector2(x, z), null);

        return result;
    }

    private void InBoundaries(Vector3 tilePosition, out Vector2 position)
    {
        position = tilePosition.ToVector2Plane();
        if (!_map.ContainsKey(position))
            throw new ArgumentException($"Tile with position {tilePosition} out of boundaries.");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size.ToVector3Plane());
        Gizmos.color = Color.white;
    }
}