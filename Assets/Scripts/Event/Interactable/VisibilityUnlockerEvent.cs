using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityUnlockerEvent : InteractableEventBehaviour<VisibilityUnlockerEvent>
{
    [SerializeField] private Transform _viewTransform;
    [SerializeField] private Map _map;
    [SerializeField] private FogOfWar _fog;

    public Transform ViewTransform => _viewTransform;
    public Map Map => _map;
    public FogOfWar Fog => _fog;

    protected override bool OnInteract(ICharacter character)
    {
        Debug.Log($"{character} interacted with VisibilityUnlockerEvent.");
        return true;
    }
}
