using UnityEngine;

public interface IPositionConverter
{
    Vector3 LocalToWorld(Vector3Int local);
    Vector3Int WorldToLocal(Vector3 local);
}