using System;
using UnityEngine;

[Serializable]
public struct Area
{
    [SerializeField] private int _radius;

    public Vector3 Center { get; set; }
    public int Radius => _radius;

    public Vector3 Clamp(Vector3 point)
    {
        var direction = point - Center;
        if (direction.magnitude > Radius)
            direction = direction.normalized * Radius;

        return direction + Center;
    }
}