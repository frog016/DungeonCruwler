using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public static Vector3[] Directions3Y = new Vector3[]
    {
        Vector3.left,
        Vector3.right, 
        Vector3.forward,
        Vector3.back, 
    };

    public static Vector3 ToVector3(this Vector3Int vector)
    {
        return new Vector3(vector.x, vector.y, vector.z);
    }

    public static Vector3Int ToVector3Int(this Vector2Int vector)
    {
        return new Vector3Int(vector.x, vector.y);
    }
    
    public static Vector3Int ToVector3IntUp(this Vector3 vector)
    {
        return new Vector3Int(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y), Mathf.CeilToInt(vector.z));
    }

    public static Vector3Int ToVector3IntDown(this Vector3 vector)
    {
        return new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
    }

    public static Vector3Int ToVector3IntPlane(this Vector2Int vector)
    {
        return new Vector3Int(vector.x, 0, vector.y);
    }
    
    public static Vector3Int ToVector3IntPlane(this Vector3Int vector)
    {
        return new Vector3Int(vector.x, 0, vector.z);
    }

    public static Vector3 ToVector3Plane(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    public static Vector3Int RotateY(this Vector3Int vector, float radiansAngle)
    {
        var x = vector.x * Mathf.Cos(radiansAngle) - vector.z * Mathf.Sin(radiansAngle);
        var z = vector.x * Mathf.Sin(radiansAngle) + vector.z * Mathf.Cos(radiansAngle);
        return new Vector3Int(Mathf.RoundToInt(x), vector.y, Mathf.RoundToInt(z));
    }

    public static Vector3 RotateY(this Vector3 vector, float radiansAngle)
    {
        var x = vector.x * Mathf.Cos(radiansAngle) - vector.z * Mathf.Sin(radiansAngle);
        var z = vector.x * Mathf.Sin(radiansAngle) + vector.z * Mathf.Cos(radiansAngle);
        return new Vector3(x, vector.y, z);
    }

    public static Vector3 RotateInPlane(this Vector3 vector, float radiansAngle)
    {
        var planeVector = vector.ToVector3Plane();
        var x = planeVector.x * Mathf.Cos(radiansAngle) - planeVector.z * Mathf.Sin(radiansAngle);
        var z = planeVector.x * Mathf.Sin(radiansAngle) + planeVector.z * Mathf.Cos(radiansAngle);
        return new Vector3(x, 0, z);
    }

    public static Vector3 Absolute(this Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    public static Vector3Int Absolute(this Vector3Int vector)
    {
        return new Vector3Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    public static Vector3 MinBy(this IEnumerable<Vector3> collection)
    {
        var (x, y, z) = collection.Min(position => Tuple.Create(position.x, position.y, position.z));
        return new Vector3(x, y, z);
    }

    public static Vector3 MaxBy(this IEnumerable<Vector3> collection)
    {
        var (x, y, z) = collection.Max(position => Tuple.Create(position.x, position.y, position.z));
        return new Vector3(x, y, z);
    }
}