using System.Collections.Generic;
using UnityEngine;

public interface IPathfinder
{
    IEnumerable<Vector3> Find(Vector3 start, Vector3 end);
}