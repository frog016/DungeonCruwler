using UnityEngine;

public interface IPositional
{
    Vector3 Center { get; }
    Vector3Int Size { get; }
    bool InBorders(Vector3 position);
}