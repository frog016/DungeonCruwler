using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDiscoverer : MonoBehaviour
{
    [SerializeField] private int _viewRadius;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Map _map;

    public int ViewRadius { get => _viewRadius; set => _viewRadius = value; }

    private void OnValidate()
    {
        if (_sphereCollider == null)
            return;

        _sphereCollider.radius = Mathf.Max(0, _viewRadius);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IVisible>(out var visible))
            StartCoroutine(WaitUntilPositionDiscovered(otherCollider.transform.position, visible));
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IVisible>(out var visible))
            visible.Hide();
    }

    private IEnumerator WaitUntilPositionDiscovered(Vector3 position, IVisible visible)
    {
        yield return new WaitUntil(() => _map.GetTile(position).Visibility == VisibilityType.Discovered);
        visible.Show();
    }
}