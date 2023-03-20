using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;

    private IPathfinder _pathfinder;
    private Coroutine _moveCoroutine;

    public void Constructor(IPathfinder pathfinder)
    {
        _pathfinder = pathfinder;
    }

    public void Move(Vector3 to)
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

        var path = _pathfinder.Find(transform.position, to);
        _moveCoroutine = StartCoroutine(MoveCoroutine(path));
    }

    private IEnumerator MoveCoroutine(IEnumerable<Vector3> path)
    {
        foreach (var target in path.Skip(1))
        {
            var direction = (target - transform.position).normalized;
            while (Vector3.Distance(transform.position, target) > 1e-1)
            {
                transform.position += direction * _speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}