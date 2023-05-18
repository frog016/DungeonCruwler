using UnityEngine;

[RequireComponent(typeof(IPlayerAttackGiver))]
public class PlayerTargetSelector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private IPlayerAttackGiver _attackGiver;

    private void Awake()
    {
        _attackGiver = GetComponent<IPlayerAttackGiver>();
    }

    private void Update()
    {
        TryFindTarget();
    }

    private void TryFindTarget()
    {
        if (!Input.GetMouseButtonDown(1))
            return;

        var mousePosition = Input.mousePosition;
        if (!_camera.ScreenPointToHit(mousePosition, out var hit) ||
            hit.transform.gameObject == gameObject ||                               // TODO: Replace this line with ITargetable that CombatStateMachine inherits
            !hit.transform.TryGetComponent<CombatEntityBehaviour>(out var machine))
            return;

        _attackGiver.Target = machine;
    }
}