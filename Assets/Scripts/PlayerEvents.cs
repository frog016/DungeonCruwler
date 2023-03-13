using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public enum Events
    {
        Battle,
        Camp,
        Chest,
        Dealer,
    }

    [SerializeField] Events _event;

    private void OnValidate()
    {
        OnEventStart(_event);
    }

    public void OnEventStart(Events eventType)
    {
        string message = "default message";

        switch (eventType)
        {
            case Events.Battle:
                message = "Oh no, there is an enemy on that card. Get ready for fight.";
                break;
            case Events.Camp:
                message = "You step on a camp card. Time for rest.";
                break;
            case Events.Chest:
                message = "You found a chest.";
                break;
            case Events.Dealer:
                message = "You found a dealer. Maybe he has something for you.";
                break;
        }
        
        Debug.Log(message);
    }
}
