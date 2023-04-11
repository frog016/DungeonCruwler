using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public static class VectorExtensions
{
    public static Vector2[] Directions2 = new Vector2[]
    {
        Vector2.up,
        Vector2.right,
        Vector2.down, 
        Vector2.left
    };

    public static Vector2Int[] Directions2Int = new Vector2Int[]
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public static Vector3Int ToVector3Int(this Vector2Int vector)
    {
        return new Vector3Int(vector.x, vector.y);
    }

    public static Vector3Int ToVector3IntPlane(this Vector2Int vector)
    {
        return new Vector3Int(vector.x, 0, vector.y);
    }
    
    public static Vector3Int ToVector3IntPlane(this Vector3Int vector)
    {
        return ToVector3IntPlane(new Vector2Int(vector.x, vector.z));
    }

    public static Vector3 ToVector3Plane(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    public static Vector3 RotateInPlane(this Vector3 vector, float radiansAngle)
    {
        var planeVector = vector.ToVector3Plane();
        var x = planeVector.x * Mathf.Cos(radiansAngle) - planeVector.z * Mathf.Sin(radiansAngle);
        var z = planeVector.x * Mathf.Sin(radiansAngle) + planeVector.z * Mathf.Cos(radiansAngle);
        return new Vector3(x, 0, z);
    }
}