using UnityEngine;

public abstract class InteractableEventBehaviour : MonoBehaviour, IInteractableEvent
{
    [SerializeField] private bool _destroyOnInteract;

    public void Interact(Character character)
    {
        OnInteract(character);
        if (_destroyOnInteract)
            Destroy(gameObject);
    }

    protected abstract void OnInteract(Character character);
}
