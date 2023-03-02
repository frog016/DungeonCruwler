using UnityEngine;

public abstract class InteractableEventBehaviour : MonoBehaviour, IInteractableEvent
{
    public abstract void Interact(Character character);
}
