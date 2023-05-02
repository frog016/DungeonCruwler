using UnityEngine;

public struct Path
{
    private int _current;
    private readonly Vector3[] _path;

    public Path(Vector3[] path)
    {
        _current = -1;
        _path = path;
    }

    public bool TryGetCurrent(int deltaIndex, out Vector3 point)
    {
        point = default;
        var current = _current + deltaIndex;
        if (current < 0 || current >= _path.Length)
            return false;

        _current = current;
        point = _path[_current];
        return true;
    }
}