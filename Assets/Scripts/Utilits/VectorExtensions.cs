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
}