using UnityEngine;

public class TestMapBuilder : MonoBehaviour
{
    [SerializeField] private Tile3D[] tiles;
    [SerializeField] private Map _map;

    private void Start()
    {
        foreach (var tile in tiles)
            _map.Add(tile);
    }
}
