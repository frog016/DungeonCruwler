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
    
    public static Vector3[] Directions3 = new Vector3[]
    {
        Vector3.up,
        Vector3.right,
        Vector3.down, 
        Vector3.left
    };

    public static Vector3 ToVector3Plane(this Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    public static Vector3 ToVector3Plane(this Vector2Int vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector2Int ToVector2Int(this Vector3 vector)
    {
        return new Vector2Int((int)vector.x, (int)vector.y);
    }

    public static Vector2 ToVector2Plane(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }
}