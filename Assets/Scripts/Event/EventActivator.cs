using UnityEngine;

[RequireComponent(typeof(Character))]
public class EventActivator : MonoBehaviour
{
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IInteractableEvent>(out var interactableEvent))
            interactableEvent.Interact(_character);
    }
}