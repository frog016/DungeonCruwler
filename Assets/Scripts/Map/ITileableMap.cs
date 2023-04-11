using System.Collections.Generic;
using UnityEngine;

public interface ITileableMap : ICollection<ITile>, IPositionConverter, IPositional
{
    Vector3 TileSize { get; }
    ITile GetTile(Vector3 tilePosition);
    IEnumerable<ITile> GetNeighbors(Vector3 tilePosition);
}