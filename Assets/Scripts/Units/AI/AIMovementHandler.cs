using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovementHandler : MovementHandler
{
    [SerializeField] private Area _loiteringArea;

    protected override void Awake()
    {
        base.Awake();
        _loiteringArea.Center = transform.position;
    }

    protected override bool TryGetPoint(out Vector3 point)
    {
        var index = Random.Range(0, VectorExtensions.Directions3Y.Length);
        var direction = VectorExtensions.Directions3Y[index];
        point = _loiteringArea.Clamp(transform.position + direction);
        return true;
    }
}