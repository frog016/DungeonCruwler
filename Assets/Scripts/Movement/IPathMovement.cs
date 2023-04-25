using System;
using System.Collections;
using UnityEngine;

public interface IPathMovement
{
    IEnumerator MoveNext();
    IEnumerator MoveBack();
    void SetDestination(Vector3 destination, int limit);
}