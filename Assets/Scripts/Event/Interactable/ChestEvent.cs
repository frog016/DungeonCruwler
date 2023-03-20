using UnityEngine;

public class ChestEvent : InteractableEventBehaviour
{
    protected override void OnInteract(Character character)
    {
        Debug.Log($"{character} found chest with gold.");
    }
}