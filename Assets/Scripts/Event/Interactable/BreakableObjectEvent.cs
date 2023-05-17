using System.Linq;

public class BreakableObjectEvent : HiddenInteractableEvent<BreakableObjectEvent>
{
    protected override bool OnInteract(ICharacter character)
    {
        if (!_hiddenObject.Detected)
            return false;

        var action = Actions?.First();
        action?.Invoke(this, character);
        return true;
    }
}
