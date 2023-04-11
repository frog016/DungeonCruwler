using UnityEngine;

public class Tile3D : MonoBehaviour, ITile
{
    [SerializeField] private TileType _tileType;

    public TileType TileType => _tileType;
    public VisibilityType Visibility { get; set; }
    public Vector3 Position => transform.position;
}
