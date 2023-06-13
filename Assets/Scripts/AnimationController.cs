using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PathMovement _pathMovement;

    private void Update()
    {
        _animator.SetFloat("Speed", _pathMovement.Speed);
    }
}
