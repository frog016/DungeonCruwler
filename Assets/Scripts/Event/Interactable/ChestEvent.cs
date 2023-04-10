using UnityEngine;

public class ChestEvent : InteractableEventBehaviour
{
    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log($"{character} found chest with gold.");
        return true;
    }
}