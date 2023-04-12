using UnityEngine;

[RequireComponent(typeof(ITileableMap))]
public class DebugVisibilityDrawer : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private float _radius;

    private ITileableMap _map;

    private void Awake()
    {
        _map = GetComponent<ITileableMap>();
    }

    private void OnDrawGizmos()
    {
        if (_map == null)
            return;

        var initialColor = Gizmos.color;
        foreach (var tile in _map.GetAll())
        {
            var color = tile.Visibility == VisibilityType.Hidden ? Color.red : Color.green;
            var position = tile.Position + new Vector3(0, _offsetY, 0);

            Gizmos.color = color;
            Gizmos.DrawSphere(position, _radius);
        }

        Gizmos.color = initialColor;
    }
}