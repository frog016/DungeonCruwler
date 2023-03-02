using UnityEngine;

public class ChestEvent : InteractableEventBehaviour
{
    public override void Interact(Character character)
    {
        Debug.Log($"{character} found chest with gold.");
    }
}