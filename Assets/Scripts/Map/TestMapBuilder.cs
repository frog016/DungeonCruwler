using UnityEngine;

public class TestMapBuilder : MonoBehaviour
{
    [SerializeField] private Platform[] tiles;
    [SerializeField] private Map _map;

    private void Start()
    {
        foreach (var tile in tiles)
            _map.Add(tile);
    }
}
