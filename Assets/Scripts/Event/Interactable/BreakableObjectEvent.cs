using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectEvent : InteractableEventBehaviour<BreakableObjectEvent>
{
    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log($"{character} interacted with BreakableObjectEvent.");
        return true;
    }
}
