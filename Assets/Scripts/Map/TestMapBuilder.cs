using UnityEngine;

public class TestMapBuilder : MonoBehaviour
{
    [SerializeField] private Tile3D[] _tiles;
    [SerializeField] private Map _map;

    private void Awake()
    {
        _map.Constructor(_tiles);
    }
}
