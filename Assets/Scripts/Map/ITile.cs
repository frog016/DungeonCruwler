using UnityEngine;

public interface ITile
{
    TileType TileType { get; }
    VisibilityType Visibility { get; set; }
    Vector3 Position { get; }
}