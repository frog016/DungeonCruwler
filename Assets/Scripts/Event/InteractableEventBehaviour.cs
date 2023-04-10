using System;
using UnityEngine;

public abstract class InteractableEventBehaviour : MonoBehaviour, IInteractableEvent
{
    [SerializeField] private bool _destroyOnInteract;

    public event Action<ICharacter> Interacted;
    public bool DestroyOnInteract { get => _destroyOnInteract; set => _destroyOnInteract = value; }

    public void Interact(ICharacter character)
    {
        if (OnInteract(character))
            Interacted?.Invoke(character);

        if (DestroyOnInteract)
            Destroy(gameObject);
    }

    protected abstract bool OnInteract(ICharacter character);
}
