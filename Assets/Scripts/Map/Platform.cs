using UnityEngine;

public class Platform : MonoBehaviour, ITile
{
    public Vector3 Position => transform.position;
}
