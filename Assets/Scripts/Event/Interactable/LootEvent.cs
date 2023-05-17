using UnityEngine;

public class LootEvent : InteractableEventBehaviour<LootEvent>
{
    [SerializeField] private string eventName = "LootEvent Object";

    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log($"{character} found {eventName}. There is nothing to find.");
        return true;
    }
}