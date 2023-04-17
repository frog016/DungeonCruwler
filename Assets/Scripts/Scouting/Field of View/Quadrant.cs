using UnityEngine;

public readonly struct Quadrant
{
    public enum Direction { North, East, South, West }

    public readonly Direction Cardinal;
    public readonly Vector3Int Origin;

    public Quadrant(Direction cardinal, Vector3Int origin)
    {
        Cardinal = cardinal;
        Origin = origin;
    }

    public Vector3Int Transform(Vector3Int tile)
    {
        var direction = Cardinal switch
        {
            Direction.North => new Vector3Int(tile.z, 0, -tile.x),
            Direction.South => new Vector3Int(tile.z, 0, tile.x),
            Direction.East => new Vector3Int(tile.x, 0, tile.z),
            Direction.West => new Vector3Int(-tile.x, 0, tile.z),
            _ => new Vector3Int()
        };

        return Origin + direction;
    }
}