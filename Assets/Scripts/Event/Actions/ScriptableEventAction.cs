using UnityEngine;

public abstract class ScriptableEventAction : ScriptableObject, IEventAction
{
    public int Chance { get; protected set; }

    public virtual void Invoke(InteractableEventHolder owner, ICharacter target)
    {
        target.Interrupted = false;
    }

    protected T CastEventAs<T>(IInteractableEvent interactableEvent) where T : IInteractableEvent
    {
        return (T)interactableEvent;
    }

    protected static void MoveCharacterForward(ICharacter character)
    {
        var characterObject = (Character)character;
        var direction = characterObject.transform.forward;
        characterObject.transform.position += direction;
    }

    protected static void MoveCharacterBack(ICharacter character)
    {
        var characterObject = (Character)character;
        var direction = characterObject.transform.forward;
        characterObject.transform.position -= direction;
    }
}