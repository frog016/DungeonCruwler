using UnityEngine;

public class FogDiscoverer : MonoBehaviour
{
    [SerializeField] private int _viewRadius;
    [SerializeField] private int _raysCount;
    [SerializeField] private SphereCollider _sphereCollider;

    public int ViewRadius { get => _viewRadius; set => _viewRadius = value; }
    public int RaysCount { get => _raysCount; set => _raysCount = value; }

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