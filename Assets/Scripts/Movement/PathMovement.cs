using System.Collections;
using System.Linq;
using UnityEngine;

public class PathMovement : MonoBehaviour, IPathMovement
{
    [SerializeField] private float _speed;

    private Path _path;
    private IPathfinder _pathfinder;

    public void Constructor(IPathfinder pathfinder)
    {
        _pathfinder = pathfinder;
    }

    public void SetDestination(Vector3 destination, int limit)
    {
        var points = _pathfinder
            .Find(transform.position, destination)
            .Skip(1)
            .Take(limit)
            .ToArray();

        _path = new Path(points);
    }

    public IEnumerator MoveNext()
    {
        return MoveToPointByDeltaIndex(1);
    }

    public IEnumerator MoveBack()
    {
        return MoveToPointByDeltaIndex(-1);
    }

    private IEnumerator MoveToPointByDeltaIndex(int deltaIndex)
    {
        if (!_path.TryGetCurrent(deltaIndex, out var point))
            yield break;

        yield return MoveCoroutine(transform.position.ToVector3Y(), point.ToVector3Y());
    }

    private IEnumerator MoveCoroutine(Vector3 from, Vector3 to)
    {
        var step = _speed / (to - from).magnitude;
        var time = 0f;
        while (time <= 1f)
        {
            time += step * Time.fixedDeltaTime;
            transform.position = Vector3.Lerp(from, to, time);
            yield return new WaitForFixedUpdate();
        }
    }
}