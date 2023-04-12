using UnityEngine;

public class TestMapBuilder : MonoBehaviour
{
    [SerializeField] private Transform _tilesRoot;
    [SerializeField] private Map _map;

    private void Awake()
    {
        var tiles = FindAllTilesIn(_tilesRoot);
        _map.Constructor(tiles);
    }

    private static ITile[] FindAllTilesIn(Transform tilesRoot)
    {
        return tilesRoot.GetComponentsInChildren<ITile>();
    }
}
