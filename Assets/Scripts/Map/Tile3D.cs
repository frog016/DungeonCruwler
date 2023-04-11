using UnityEngine;

public class Tile3D : MonoBehaviour, ITile
{
    public Vector3 Position => transform.position;
}
