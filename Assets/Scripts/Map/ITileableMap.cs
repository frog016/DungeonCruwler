using System.Collections.Generic;
using UnityEngine;

public interface ITileableMap
{
    void Add(ITile tile);
    void Remove(ITile tile);
    ITile GetTile(Vector3 tilePosition);
    IEnumerable<ITile> GetNeighbors(Vector3 tilePosition);
    IEnumerable<ITile> GetTiles();
}