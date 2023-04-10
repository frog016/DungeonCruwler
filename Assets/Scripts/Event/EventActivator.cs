using UnityEngine;

public class EventActivator : MonoBehaviour
{
    private ICharacter _character;

    public void Constructor(ICharacter character)
    {
        _character = character;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IInteractableEvent>(out var interactableEvent))
            interactableEvent.Interact(_character);
    }
}