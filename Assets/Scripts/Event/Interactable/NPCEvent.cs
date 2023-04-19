using UnityEngine;

public class NPCEvent : InteractableEventBehaviour<NPCEvent>
{
    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log("You are met the NPC.");
        return true;
    }
}