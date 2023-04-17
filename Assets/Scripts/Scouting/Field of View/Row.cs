using System.Collections.Generic;
using UnityEngine;

public struct Row
{
    public int Depth { get; set; }
    public float StartSlope { get; set; }
    public float EndSlope { get; set; }

    private readonly int _maxDepth;

    public Row(int depth, int maxDepth, float startSlope, float endSlope)
    {
        Depth = depth;
        StartSlope = startSlope;
        EndSlope = endSlope;
        _maxDepth = maxDepth;
    }

    public IEnumerable<Vector3Int> GetMapPositions()
    {
        var minColumn = Mathf.RoundToInt(Depth * StartSlope);
        var maxColumn = Mathf.RoundToInt(Depth * EndSlope);

        for (var column = minColumn; column <= maxColumn; column++)
            yield return new Vector3Int(Depth, 0, column);
    }

    public bool TryNext(out Row row)
    {
        row = new Row(Depth + 1, _maxDepth, StartSlope, EndSlope);
        return row.Depth <= _maxDepth;
    }
}