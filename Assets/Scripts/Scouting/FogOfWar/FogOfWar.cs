using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    [SerializeField] private Map _map;

    [SerializeField, Range(1, 30)] private float _refreshRate;
    [SerializeField, Range(0, 100)] private float _fogHeight;
    [SerializeField] private FogRenderer _fogPrefab;
    [SerializeField] private List<FogDiscoverer> _fogDiscoverers;

    private float _refreshRateTimer;
    private FogRenderer _fog;
    private IVisibleArea _visibleArea;

    private void Start()
    {
        _visibleArea = new ShadowCastingVisibleArea(_map);
        InitializeFog();
        ForceUpdateFog();
    }

    private void Update()
    {
        UpdateFog();
    }

    public void UpdateFog()
    {
        if (TryRefresh())
            return;

        ResetTileVisibility();
        foreach (var discoverer in _fogDiscoverers)
            _visibleArea.DiscoverArea(discoverer.transform.position, discoverer.ViewRadius);

        _fog.UpdateTargetTexture(GetVisibilityMap());
        _fog.UpdateBufferTexture();
    }

    private void InitializeFog()
    {
        _fog = Instantiate(_fogPrefab);
        _fog.name = "[RUNTIME] FogPlane";

        _fog.transform.position = new Vector3(_map.Center.x, _map.Center.y + _fogHeight, _map.Center.z);
        _fog.transform.localScale = _map.Size.ToVector3() / 10f;

        _fog.InitializeRenderer(
            new Texture2D(_map.Size.x, _map.Size.z),
            new Texture2D(_map.Size.x, _map.Size.z));
    }

    private void ForceUpdateFog()
    {
        ResetTileVisibility();
        foreach (var discoverer in _fogDiscoverers)
            _visibleArea.DiscoverArea(discoverer.transform.position, discoverer.ViewRadius);

        _fog.UpdateTargetTexture(GetVisibilityMap());
        Graphics.CopyTexture(_fog.TargetTexture, _fog.BufferTexture);
    }

    private void ResetTileVisibility()
    {
        foreach (var tile in _map.GetAll())
            tile.Visibility = VisibilityType.Hidden;
    }

    private VisibilityType[] GetVisibilityMap()
    {
        return _map.GetAll()
            .OrderBy(tile => Tuple.Create(tile.Position.z, tile.Position.x))
            .Select(tile => tile.Visibility)
            .ToArray();
    }

    private bool TryRefresh()
    {
        _refreshRateTimer += Time.deltaTime;
        if (_refreshRateTimer < 1 / _refreshRate)
        {
            _fog.UpdateBufferTexture();
            return true;
        }

        _refreshRateTimer -= 1 / _refreshRate;
        return false;
    }
}