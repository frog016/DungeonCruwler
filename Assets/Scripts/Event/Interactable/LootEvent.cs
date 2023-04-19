using UnityEngine;

public class LootEvent : InteractableEventBehaviour<LootEvent>
{
    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log($"{character} found chest with gold.");
        return true;
    }
}