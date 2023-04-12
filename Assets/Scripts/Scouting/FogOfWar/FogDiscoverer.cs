using UnityEngine;

public class FogDiscoverer : MonoBehaviour
{
    [SerializeField] private int _viewRadius;
    [SerializeField] private int _raysCount;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Map _map;

    public int RaysCount => _raysCount;
    public int ViewRadius { get => _viewRadius; set => _viewRadius = value; }

    private void OnValidate()
    {
        if (_sphereCollider == null)
            return;
        _sphereCollider.radius = ViewRadius;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IVisible>(out var visible))
            visible.Show();
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IVisible>(out var visible))
            visible.Hide();
    }
}