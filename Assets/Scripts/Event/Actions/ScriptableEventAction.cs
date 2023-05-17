using UnityEngine;

public abstract class ScriptableEventAction : ScriptableObject, IEventAction
{
    [SerializeField] private DescriptionData _data;

    public DescriptionData DescriptionData => _data;

    public virtual void Invoke(EventBehaviour owner, ICharacter target)
    {
        target.Interrupted = false;
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